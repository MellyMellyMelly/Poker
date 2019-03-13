using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using Base.Objects;
using Base.Models;
namespace Base.Factory
{
    internal class HandFactory
    {
        private string part1 = "(rankOne, rankTwo, suited, wins, games, highcard, highcardWins, pair, pairWins, twopair, twopairWins, threekind, threekindWins, straight, straightWins, flush, flushWins, fullhouse, fullhouseWins, fourkind, fourkindWins, straightflush, straightflushWins) VALUES ";
        private string connectionString;
        private string[] tableName;
        public HandFactory(Record[] records, int name)
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=poker2;SslMode=None";
            tableName = new string[]{"two","three","four","five","six","seven","eight","nine","ten","eleven","twelve"};
            var all = FindAll(tableName[name]).ToList();
            HandData item = new HandData();
            if(all.Count == 0)
            {
                for(int i = 0; i < records.Length; i++)
                {
                    item = ModifyAll(records[i]);
                    all.Add(item);
                    Add(item, tableName[name]);
                }
            }
            else
            {
                for(int i = 0; i < all.Count; i++)
                {
                    records[i].Update(all, i);
                    item.Assign(records[i]);
                    Update(item, tableName[name]);
                }
            }
            System.Console.WriteLine("Max Scherzer");
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        private IEnumerable<HandData> FindAll(string name)
        {
            System.Console.WriteLine(name);
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<HandData>($"SELECT * FROM {name}");
            }
        }
        private void Add(HandData item, string name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string part2 = $"(@rankOne, @rankTwo, @suited, @wins , @games, @highcard, @highcardWins, @pair, @pairWins, @twopair, @twopairWins, @threekind, @threekindWins, @straight, @straightWins, @flush, @flushWins, @fullhouse, @fullhouseWins, @fourkind, @fourkindWins, @straightflush, @straightflushWins)";
                string query =  $"INSERT INTO {name} "+ part1 + part2;
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        private void Update(HandData item, string name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query =  $"UPDATE {name} SET wins = {item.wins}, games = {item.games}, highcard = {item.highcard}, highcardWins = {item.highcardWins}, pair = {item.pair}, pairWins = {item.pairWins}, twopair = {item.twopair}, twopairWins = {item.twopairWins}, threekind = {item.threekind}, threekindWins = {item.threekindWins}, straight = {item.straight}, straightWins = {item.straightWins}, flush = {item.flush}, flushWins = {item.flushWins}, fullhouse = {item.fullhouse}, fullhouseWins = {item.fullhouseWins}, fourkind = {item.fourkind}, fourkindWins = {item.fourkindWins}, straightflush = {item.straightflush}, straightflushWins = {item.straightflushWins} WHERE id = {item.Id}";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        private HandData ModifyAll(Record record)
        {
            HandData item = new HandData();
            item.Assign(record);
            return item;
        }
    }
}