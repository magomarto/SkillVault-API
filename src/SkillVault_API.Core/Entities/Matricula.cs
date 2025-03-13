using System.ComponentModel.DataAnnotations;

namespace SkillVault_API.Core.Entities
{
    public class Matricula
    {
        // Construtor para inicializar valores padrão e garantir integridade
        public Matricula(int alunoId, int cursoId, DateTime dataMatricula)
        {
            AlunoId = alunoId;
            CursoId = cursoId;
            DataMatricula = dataMatricula;
        }

        protected Matricula() { }

        public int Id { get; private set; }

        [Required(ErrorMessage = "O ID do aluno é obrigatório.")]
        public int AlunoId { get; private set; }

        [Required(ErrorMessage = "O ID do curso é obrigatório.")]
        public int CursoId { get; private set; }

        [Required(ErrorMessage = "A data de matrícula é obrigatória.")]
        public DateTime DataMatricula { get; private set; }

        public virtual Aluno Aluno { get; private set; } // Relacionamento com Aluno (uma matrícula pertence a um aluno)
        public virtual Curso Curso { get; private set; } // relacionamento com Curso (uma matricula pertence a um curso)
    }

        
}