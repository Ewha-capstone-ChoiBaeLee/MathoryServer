using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class Quiz
    {
        public int Id { get; set; }
        public int Part { get; set; }
        public string Problem { get; set; }
        public string Answer { get; set; }
        public string Equation { get; set; }
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }
    }
}
