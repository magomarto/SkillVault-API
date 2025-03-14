using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SkillVault_API.Core.Enums;

namespace SkillVault_API.Core.Entities
{
    public class Disciplina
    {
        // Construtor principal
        public Disciplina(
            string nomeDisciplina, 
            string descricao, 
            int cargaHoraria, 
            int professorId)
        {
            NomeDisciplina = nomeDisciplina;
            Descricao = descricao;
            CargaHoraria = cargaHoraria;
            ProfessorId = professorId;
            DataCriacao = DateTime.UtcNow;
            Status = StatusDisciplina.Ativa;

            Validar();
        }

        // Construtor vazio para o EF Core
        protected Disciplina() { }

        // Propriedades
        public int DisciplinaId { get; private set; }

        [Required(ErrorMessage = "O nome da disciplina é obrigatório.")]
        [StringLength(100, ErrorMessage = "Máximo de 100 caracteres.")]
        public string NomeDisciplina { get; private set; }

        [Required(ErrorMessage = "A descrição é obrigatória.")]
        [StringLength(500, ErrorMessage = "Máximo de 500 caracteres.")]
        public string Descricao { get; private set; }

        [Required(ErrorMessage = "A carga horária é obrigatória.")]
        [Range(1, 500, ErrorMessage = "Carga horária deve ser entre 1 e 500 horas.")]
        public int CargaHoraria { get; private set; }

        public DateTime DataCriacao { get; private set; }
        public DateTime? DataAtualizacao { get; private set; }

        [Required(ErrorMessage = "O status é obrigatório.")]
        public StatusDisciplina Status { get; private set; }

        // Relacionamento com Professor (N:1)
        public int ProfessorId { get; private set; }
        public virtual Professor Professor { get; private set; }

        // Relacionamento com Cursos (N:N via tabela intermediária)
        public virtual ICollection<CursoDisciplina> Cursos { get; private set; } = new List<CursoDisciplina>();

        // Método para validação
        private void Validar()
        {
            if (CargaHoraria <= 0)
                throw new ArgumentException("Carga horária inválida.");
        }

        // Método para atualização
        public void Atualizar(string nome, string descricao, StatusDisciplina status)
        {
            NomeDisciplina = nome;
            Descricao = descricao;
            Status = status;
            DataAtualizacao = DateTime.UtcNow;
        }
    }
}