using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class Story
    {
        public int Id { get; set; }
        public int Part { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }

    }
}
