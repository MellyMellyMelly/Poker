using System.ComponentModel.DataAnnotations;
using Base.Objects;
namespace Base.Models
{
    public class HandData
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        public int cardOne { get; set; }
        [Required]
        public int cardTwo { get; set; }
        [Required]
        public int wins { get; set; }
        [Required]
        public int games { get; set; }
        public void Assign(Record[] records, int index)
        {
            Id = records[index].handID;
            cardOne = records[index].Coordinates[0];
            cardTwo = records[index].Coordinates[1];
            wins = records[index].Wins;
            games = records[index].Games;
        }
    }
}