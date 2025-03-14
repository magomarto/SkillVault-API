using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillVault_API.Core.Entities
{
    public class Professor
    {
        // Construtor principal
        public Professor(string nomeProfessor, int usuarioId)
        {
            NomeProfessor = nomeProfessor;
            UsuarioId = usuarioId; // FK para Usuario
            DataCadastro = DateTime.UtcNow;
            Validar();
        }
        protected Professor() { }

        public int ProfessorId { get; private set; }

        [Required(ErrorMessage = "O nome do professor é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        public string NomeProfessor { get; private set; }

        public DateTime DataCadastro { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        public int UsuarioId { get; private set; } //relação com usuario (1:1)
        public virtual Usuario Usuario { get; private set; }

        public virtual ICollection<Disciplina> Disciplinas { get; private set; } = new List<Disciplina>(); // relação com disciplina (1:N)

        private void Validar()
        {
            if (string.IsNullOrWhiteSpace(NomeProfessor))
                throw new ArgumentException("Nome do professor não pode ser vazio.");
        }

        public void AtualizarNome(string novoNome)
        {
            NomeProfessor = novoNome;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}