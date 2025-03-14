namespace SkillVault_API.Core.Entities
{
    public class CursoDisciplina
    {
        public int CursoId { get; private set; }
        public virtual Curso Curso { get; private set; }
        public int DisciplinaId { get; private set; }
        public virtual Disciplina Disciplina { get; private set; }
        
    }
}