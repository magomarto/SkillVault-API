using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillVault_API.src.SkillVault_API.Core.Entities
{
    public class Aluno
    {
        public int Id { get; set;}
        public string Nome { get; set; } // depois ver sobre : Non-nullable property 
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }


    }
}