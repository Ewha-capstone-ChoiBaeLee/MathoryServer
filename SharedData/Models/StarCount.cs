using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedData.Models
{
    public class StarCount
    {

        [Key]
        public string UserId { get; set; }
        public int LevelOne { get; set; }
        public int LevelTwo { get; set; }
        public int LevelThree { get; set; }
        public int LevelFour { get; set; }
        public int LevelFive { get; set; }
        public int LevelSix { get; set; }
        public int LevelSeven { get; set;}
        public int LevelEight { get; set; }
        public int LevelNine { get; set;}
        public int LevelTen { get; set; }
        public int LevelEleven { get; set;}
        public int LevelTwelve { get; set;}

        [ForeignKey("UserId")]
        public UserInformation UserInformation { get; set; }

    }
}
