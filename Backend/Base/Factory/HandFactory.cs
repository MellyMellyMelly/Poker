using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using Base.Objects;
using Base.Models;
namespace Base.Factory
{
    public class HandFactory
    {
        private string connectionString;
        private string[] tableName;
        public HandFactory(Record[] records, int name)
        {
            connectionString = "server=localhost;userid=root;password=root;port=3306;database=poker;SslMode=None";
            tableName = new string[]{"two","three","four","five","six","seven","eight","nine","ten","eleven","twelve"};
            var all = FindAll(tableName[name]).ToList();
            HandData item = new HandData();
            if(all.Count == 0)
            {
                int index = 0;
                for(int i = 0; i < 51; i++)
                {
                    for(int j = i+1; j < 52; j++)
                    {
                        item = ModifyAll(records, i, j, index);
                        all.Add(item);
                        item = all[all.Count-1];
                        Add(item, tableName[name]);
                        index++;
                    }
                }
            }
            else
            {
                for(int i = 0; i < all.Count; i++)
                {
                    records[i].Update(all, i);
                    item.Assign(records, i);
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
                string query =  $"INSERT INTO {name} (cardOne, cardTwo, wins, games) VALUES (@cardOne, @cardTwo, @wins, @games)";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        private void Update(HandData item, string name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query =  $"UPDATE {name} SET wins = {item.wins}, games = {item.games} WHERE id = {item.Id}";
                dbConnection.Open();
                dbConnection.Execute(query, item);
            }
        }
        private HandData ModifyAll(Record[] records, int i, int j, int index)
        {
            HandData item = new HandData();
            item.cardOne = i;
            item.cardTwo = j;
            item.wins = records[index].Wins;
            item.games = records[index].Games;
            return item;
        }
    }
}