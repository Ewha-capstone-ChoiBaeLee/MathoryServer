using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedData.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string Subject_Name { get; set; }
    }
}
