using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillVault_API.Core.Enums;

namespace SkillVault_API.Core.Entities
{
    public class Curso
    {
        // Construtor principal
        public Curso(
            string nomeCurso, 
            string descricao, 
            CategoriaCurso categoria, 
            int duracaoHoras, 
            int coordenadorId)
        {
            NomeCurso = nomeCurso;
            Descricao = descricao;
            Categoria = categoria;
            DuracaoHoras = duracaoHoras;
            CoordenadorId = coordenadorId;
            DataCriacao = DateTime.UtcNow;
            Status = StatusCurso.Ativo;

            Validar();
        }

        protected Curso() { }

        public int CursoId { get; private set; }

        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [StringLength(150, ErrorMessage = "Máximo de 150 caracteres.")]
        public string NomeCurso { get; private set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "Máximo de 500 caracteres.")]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public CategoriaCurso Categoria { get; private set; }

        [Required(ErrorMessage = "A duração é obrigatória.")]
        [Range(1, 1000, ErrorMessage = "Duração deve ser entre 1 e 1000 horas.")]
        public int DuracaoHoras { get; private set; }

        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusCurso Status { get; private set; }

        public int CoordenadorId { get; private set; } // 1:N (relação com coordenador)
        public virtual Coordenador Coordenador { get; private set; }

        public virtual ICollection<CursoDisciplina> Disciplinas { get; private set; } = new List<CursoDisciplina>(); //N:N via tabela intermediária

        public virtual ICollection<Matricula> Matriculas { get; private set; } = new List<Matricula>(); // 1 curso tem N matrículas

        // Método para validação
        private void Validar()
        {
            if (DuracaoHoras <= 0)
                throw new ArgumentException("Duração do curso inválida.");
        }

        // Método para atualização
        public void Atualizar(string nome, string descricao, StatusCurso status)
        {
            NomeCurso = nome;
            Descricao = descricao;
            Status = status;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}