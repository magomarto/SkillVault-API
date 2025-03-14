using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillVault_API.Core.Enums;

namespace SkillVault_API.Core.Entities
{
    public class Matricula
    {
        public Matricula(int alunoId, int cursoId, StatusMatricula status)
        {
            AlunoId = alunoId;
            CursoId = cursoId;
            Status = status;
            DataMatricula = DateTime.UtcNow;
            Validar();
        }

        protected Matricula() { }

        public int MatriculaId { get; private set; }

        [Required(ErrorMessage = "O aluno é obrigatório.")]
        public int AlunoId { get; private set; }

        [Required(ErrorMessage = "O curso é obrigatório.")]
        public int CursoId { get; private set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusMatricula Status { get; private set; }

        [Range(0, 10, ErrorMessage = "A nota deve ser entre 0 e 10.")]
        public decimal? NotaFinal { get; private set; } 

        public DateTime DataMatricula { get; private set; }
        public DateTime? DataConclusao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        // Relacionamentos
        public virtual Aluno Aluno { get; private set; }
        public virtual Curso Curso { get; private set; }

        private void Validar()
        {
            if (AlunoId <= 0 || CursoId <= 0)
                throw new ArgumentException("Aluno ou curso inválido.");
        }

        public void AtualizarStatus(StatusMatricula novoStatus)
        {
            Status = novoStatus;
            DataAtualizacao = DateTime.UtcNow;

            if (novoStatus == StatusMatricula.Concluida)
                DataConclusao = DateTime.UtcNow;
        }

        public void AtribuirNotaFinal(decimal nota)
        {
            if (Status != StatusMatricula.Concluida)
                throw new InvalidOperationException("A nota só pode ser atribuída a matrículas concluídas.");

            NotaFinal = nota;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}