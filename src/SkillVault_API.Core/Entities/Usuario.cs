using System.ComponentModel.DataAnnotations;

namespace SkillVault_API.Core.Entities
{
    public class Usuario
    {
        public Usuario(string email, string senhaHash, string role)
        {
            Email = email;
            SenhaHash = senhaHash;
            Role = role;
            DataCadastro = DateTime.UtcNow;
        }

        protected Usuario() { }

        public int UsuarioId { get; private set; }

        [Required]
        [EmailAddress]
        [MaxLength(256)] 
        public string Email { get; private set; }

        [Required]
        [MaxLength(128)] // Hash da senha ( BCrypt talvez? pesquisar dps)
        public string SenhaHash { get; private set; }

        [Required]
        [MaxLength(20)] 
        public string Role { get; private set; }

        public DateTime DataCadastro { get; private set; }

        // Relacionamentos
        public virtual Aluno Aluno { get; private set; }
        public virtual Coordenador Coordenador { get; private set; }
        public virtual Professor Professor { get; private set; }
    }
}