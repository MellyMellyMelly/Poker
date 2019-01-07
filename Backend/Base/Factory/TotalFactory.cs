using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;
using Base.Objects;
using Base.Models;
namespace Base.Factory
{
    public class TotalFactory
    {
        private string connectionString;
        private string name;
        internal TotalFactory(HandTotal survey, int playerTotal)
        {
            connectionString = "FIGURE IT OUT YOURSELF";
            name = "FIGURE IT OUT YOURSELF";
            var all = FindAll(name, playerTotal).FirstOrDefault();
            if(all == null)
            {
                Add(survey, name, playerTotal);
            }
            else
            {
                PropertyCopier<HandTotal, HandTotal>.UpdateHandTotal(all, survey);
                survey.roundSize = playerTotal;
                Update(survey, name);
            }
        }
        internal IDbConnection Connection
        {
            get {
                return new MySqlConnection(connectionString);
            }
        }
        private IEnumerable<HandTotal> FindAll(string name, int total)
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<HandTotal>($"SELECT * FROM {name} WHERE roundSize = {total}");
            }
        }
        private void Add(HandTotal survey, string name, int total)
        {
            survey.roundSize = total;
            using (IDbConnection dbConnection = Connection)
            {
                string variables = $"(roundSize, splits, games, highcard, highcardWins, pair, pairWins, twopair, twopairWins, threekind, threekindWins, straight, straightWins, flush, flushWins, fullhouse, fullhouseWins, fourkind, fourkindWins, straightflush, straightflushWins)";
                string values = $"(@roundSize, @splits, @games, @highcard, @highcardWins, @pair, @pairWins, @twopair, @twopairWins, @threekind, @threekindWins, @straight, @straightWins, @flush, @flushWins, @fullhouse, @fullhouseWins, @fourkind, @fourkindWins, @straightflush, @straightflushWins)";
                string query = $"INSERT INTO {name} {variables} VALUES {values}";
                dbConnection.Open();
                dbConnection.Execute(query, survey);
            }
        }
        private void Update(HandTotal copy, string name)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string query =  $"UPDATE {name} SET splits = {copy.splits}, games = {copy.games}, highcard = {copy.highcard}, highcardWins = {copy.highcardWins}, pair = {copy.pair}, pairWins = {copy.pairWins}, twopair = {copy.twopair}, twopairWins = {copy.twopairWins}, threekind = {copy.threekind}, threekindWins = {copy.threekindWins}, straight = {copy.straight}, straightWins = {copy.straightWins}, flush = {copy.flush}, flushWins = {copy.flushWins}, fullhouse = {copy.fullhouse}, fullhouseWins = {copy.fullhouseWins}, fourkind = {copy.fourkind}, fourkindWins = {copy.fourkindWins}, straightflush = {copy.straightflush}, straightflushWins = {copy.straightflushWins} WHERE roundSize = {copy.roundSize}";
                dbConnection.Open();
                dbConnection.Execute(query, copy);
            }
        }
    }
}