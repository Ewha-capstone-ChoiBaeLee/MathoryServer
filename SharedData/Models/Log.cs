using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class Log
    {
        public string UserId { get; set; }
        public UserInformation UserInformation { get; set; }
        public int Year { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string Equation { get; set; }
        public string Answer { get; set; }

    }
}
