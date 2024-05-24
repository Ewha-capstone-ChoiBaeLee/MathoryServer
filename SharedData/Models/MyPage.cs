using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
        public class MyPage
        {
            public string UserId { get; set; }
            public int Year { get; set; }
            public int SubjectId { get; set; }
            public int Solved_Questions { get; set; }
            public int Correct_Questions { get; set;}

            [ForeignKey("UserId")]
            public UserInformation UserInformation { get; set; }
            [ForeignKey("SubjectId")]
            public Subject Subject { get; set; }

        }
}
