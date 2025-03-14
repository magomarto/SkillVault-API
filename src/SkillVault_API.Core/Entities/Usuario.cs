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

        [Required][EmailAddress]
        public string Email { get; private set; }

        [Required]
        public string SenhaHash { get; private set; } // Hash da senha ( BCrypt talvez? pesquisar dps)

        [Required]
        public string Role { get; private set; } // roles: "Admin", "Coordenador", "Professor", "Aluno"

        public DateTime DataCadastro { get; private set; }
        public virtual Aluno Aluno { get; private set; }
        public virtual Coordenador Coordenador { get; private set; }
        public virtual Professor Professor { get; private set; }
    }
}