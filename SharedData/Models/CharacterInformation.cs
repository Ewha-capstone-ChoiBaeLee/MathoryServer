using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedData.Models
{
    public class CharacterInformation
    {
        [Key]
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }

        // (보류) public string CharacterDescription { get; set; }
    }
}
