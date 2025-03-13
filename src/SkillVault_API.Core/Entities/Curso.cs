using System.ComponentModel.DataAnnotations;


namespace SkillVault_API.Core.Entities
{
    public class Curso
    {

        public Curso(string nomeCurso, string descricao, string categoriaCurso, int duracaoCurso) // método construtor principal
        {
            NomeCurso = nomeCurso;
            Descricao = descricao;
            CategoriaCurso = categoriaCurso;
            DuracaoCurso = duracaoCurso;
            DataCriacao = DateTime.UtcNow;

        }

        protected Curso() { } //contrutor vazio para o Entity Framework Core criar instancias da classe durante as operações do DB
        // o protected impede que o construtor seja chamado diretamente fora da classe 
        public int IdCurso {get; private set;} // idCurso sera a chave primaria do db
        // private set serve para que o só entitityframeworkcore possa definir o valor (imutabilidade)

        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage ="Minimo de 3 e máximo 100 caracteres")]

        public string NomeCurso { get; private set; }

        [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
        [StringLength(500, ErrorMessage = "Máximo de 500 caracteres.")]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = "A duração do curso é obrigatória.")]
        [Range(1, 7, ErrorMessage = "A duração deve ser entre 1 a 6 anos")]
        public int DuracaoCurso { get; private set; }
        public DateTime DataCriacao { get; private set; } 

        [Required(ErrorMessage = "A categoria do curso é obrigatória.")]
        public string CategoriaCurso { get; private set; }

        public virtual ICollection<Matricula> Matriculas { get; private set; } = new List<Matricula>();// relacionamento com matriculas
        
    }
}