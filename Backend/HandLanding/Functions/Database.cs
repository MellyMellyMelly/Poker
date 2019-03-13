using System;
using System.Collections.Generic;
using HandLanding.Objects;
using System.Linq;
namespace HandLanding.Functions
{
    public static class Database
    {
        public static Record Update(Record record, Object[] results)
        {
            List<Player> winners = (List<Player>)(results[0]);
            List<Player> losers = (List<Player>)(results[1]);
            record.Games++;
            int index = 0;
            bool searching = true;
            while(index < winners.Count && searching)
            {
                if(winners[index].name == record.name)
                {
                    record.Wins++;
                    if((int)winners[index].result[0] == record.resultSeek[0])
                    {
                        record.FavorableOne++;
                        record.FavorableOneWins++;
                    }
                    else if(record.resultSeek.Length == 2)
                    {
                        if((int)winners[index].result[0] == record.resultSeek[1]){
                            record.FavorableTwo++;
                            record.FavorableTwoWins++;
                        }
                    }
                    searching = false;
                }
                index++;
            }
            index = 0;
            while(index < losers.Count && searching)
            {
                if(losers[index].name == record.name)
                {
                    if((int)losers[index].result[0] == record.resultSeek[0])
                    {
                        record.FavorableOne++;
                    }
                    else if(record.resultSeek.Length == 2)
                    {
                        if((int)winners[index].result[0] == record.resultSeek[1]){
                            record.FavorableTwo++;
                        }
                    }
                    searching = false;
                }
                index++;
            }
            return record;
        }
    }
}