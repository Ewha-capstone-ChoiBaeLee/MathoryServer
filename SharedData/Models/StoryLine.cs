using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class StoryLine
    {
        public int Id { get; set; }
        public int Num { get; set; }
        public int Part { get; set; }
        public string Name { get; set; }
        public string Story {  get; set; }
    }
}
