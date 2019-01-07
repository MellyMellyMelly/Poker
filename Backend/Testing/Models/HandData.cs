using System.ComponentModel.DataAnnotations;
using Base.Objects;
namespace Base.Models
{
    public class HandData
    {
        [Key]
        public long Id { get; set; }
 
        [Required]
        public int rankOne { get; set; }
        [Required]
        public int rankTwo { get; set; }
        [Required]
        public string suited { get; set;}
        [Required]
        public int wins {get; set;}
        [Required]
        public int games { get; set; }
        [Required]
        public int highcard { get; set;}
        [Required]
        public int highcardWins { get; set;}
        [Required]
        public int pair { get; set;}
        [Required]
        public int pairWins { get; set;}
        [Required]
        public int twopair { get; set;}
        [Required]
        public int twopairWins { get; set;}
        [Required]
        public int threekind { get; set;}
        [Required]
        public int threekindWins { get; set;}
        [Required]
        public int straight { get; set;}
        [Required]
        public int straightWins { get; set;}
        [Required]
        public int flush { get; set;}
        [Required]
        public int flushWins { get; set;}
        [Required]
        public int fullhouse { get; set;}
        [Required]
        public int fullhouseWins { get; set;}
        [Required]
        public int fourkind { get; set;}
        [Required]
        public int fourkindWins { get; set;}
        [Required]
        public int straightflush { get; set;}
        [Required]
        public int straightflushWins { get; set;}
        internal void Assign(Record[] records, int index)
        {
            Id = records[index].handID;
            rankOne = records[index].Coordinates[0];
            rankTwo = records[index].Coordinates[1];
            PropertyCopier<Record, HandData>.Copy(records[index], this);
        }
    }
}