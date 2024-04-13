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
        public int Id { get; set; }
        public int CharacterId { get; set; }
        public string CharacterName { get; set; }
        public string CharacterPersonality { get; set; }
    }
}
