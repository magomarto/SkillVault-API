using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SkillVault_API.src.SkillVault_API.Core.Entities
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descrição { get; set; }
        public int CargaHoraria { get; set; }
        
    }
}