using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SharedData.Models
{
    public class UserInformation
    {
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserPW { get; set; } 
        public string UserName { get; set; }
        public int UserYear { get; set; }
        public int UserLevel { get; set; }
    }
}
