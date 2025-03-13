using System.ComponentModel.DataAnnotations;

namespace SkillVault_API.Core.Entities
{
    public class Aluno
    {
        public Aluno(string nomeAluno, string emailAluno, DateTime dataNascimento)
        {
            NomeAluno = nomeAluno;
            EmailAluno = emailAluno;
            DataNascimento = dataNascimento;
            DataCadastro = DateTime.UtcNow;
        }

        protected Aluno(){ }
        
        public int IdAluno {get; private set;}

        [Required(ErrorMessage = "O nome do aluno é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimo de 3 e máximo 100 caracteres.")]
        public string NomeAluno { get; private set; }

        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string EmailAluno { get; private set; }

        [Required(ErrorMessage = "A data de nascimento é obrigatória.")]
        public DateTime DataNascimento { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public virtual ICollection<Matricula> Matriculas { get; private set; } = new List<Matricula>();
    }
}
