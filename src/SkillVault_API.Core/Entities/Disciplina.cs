using System.ComponentModel.DataAnnotations;

namespace SkillVault_API.Core.Entities
{
    public class Disciplina
    {
         public Disciplina(string nomeDisciplina, int cargaHoraria, int cursoId)
        {
            NomeDisciplina = nomeDisciplina;
            CargaHoraria = cargaHoraria;
            CursoId = cursoId;
            DataCriacao = DateTime.UtcNow; // Define a data de criação automaticamente
        }

        protected Disciplina() { }

        public int Id { get; private set; }

        [Required(ErrorMessage = "O nome da disciplina é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 100 caracteres.")]
        public string NomeDisciplina { get; private set; }

        [Required(ErrorMessage = "A carga horária da disciplina é obrigatória.")]
        [Range(1, 200, ErrorMessage = "A carga horária deve ser entre 1 e 200 horas.")]
        public int CargaHoraria { get; private set; }

        public DateTime DataCriacao { get; private set; } 

        public int CursoId { get; private set; } // Relacionamento com Curso (uma disciplina pertence a um curso)
        public virtual Curso Curso { get; private set; } // Navegação para o curso

        public virtual ICollection<Matricula> Matriculas { get; private set; } = new List<Matricula>(); // Relacionamento com Matrículas (uma disciplina pode ter várias matrículas)
        
    }
}