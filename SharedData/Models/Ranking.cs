using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class Ranking
    {
        public int Id { get; set; }
        public string Ranking_Name { get; set; }
        public int Min_Score { get; set; }
        public int Max_Score { get; set; }
    }
}
