using System.ComponentModel.DataAnnotations;

namespace SkillVault_API.Core.Entities
{
    public class Coordenador
    {
        public Coordenador(string nomeCoordenador, int usuarioId)
        {
            NomeCoordenador = nomeCoordenador;
            UsuarioId = usuarioId; // vai ser FK para Usuario
            DataCadastro = DateTime.UtcNow;

            if (string.IsNullOrWhiteSpace(nomeCoordenador))
                throw new ArgumentException("Nome do coordenador é obrigatório.");
        }

        protected Coordenador() { }

        public int CoordenadorId { get; private set; }

        [Required(ErrorMessage = "O nome do coordenador é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        public string NomeCoordenador { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public int UsuarioId { get; private set; } // se relacionacom usuario (1:1)
        public virtual Usuario Usuario { get; private set; }

        public virtual ICollection<Curso> Cursos { get; private set; } = new List<Curso>(); // relacionamento com Cursos (1:N)
    }
}