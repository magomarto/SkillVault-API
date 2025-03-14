using System.ComponentModel.DataAnnotations;

namespace SkillVault_API.Core.Entities
{
    public class Aluno
    {
        // Construtor principal
        public Aluno(string nomeAluno, string emailAluno, DateTime dataNascimento, int usuarioId)
        {
            NomeAluno = nomeAluno;
            EmailAluno = emailAluno;
            DataNascimento = dataNascimento;
            UsuarioId = usuarioId; // FK para Usuario
            DataCadastro = DateTime.UtcNow;

            if (dataNascimento > DateTime.UtcNow.AddYears(-5)) //validando data de nascimento
                throw new ArgumentException("Data de nascimento inválida.");
        }

        // Construtor vazio para o EF Core
        protected Aluno() { }

        // Propriedades
        public int AlunoId { get; private set; }

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Mínimo de 3 e máximo de 100 caracteres.")]
        public string NomeAluno { get; private set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string EmailAluno { get; private set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; private set; }

        public DateTime DataCadastro { get; private set; }

        // Relacionamento com Usuario (1:1)
        public int UsuarioId { get; private set; }
        public virtual Usuario Usuario { get; private set; }

        // Relacionamento com Matrículas (1:N)
        public virtual ICollection<Matricula> Matriculas { get; private set; } = new List<Matricula>();
    }
}
