using Microsoft.EntityFrameworkCore;
using SkillVault_API.Core.Entities;

namespace SkillVault_API.Infrastructure.Data 
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSets
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Coordenador> Coordenadores { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<CursoDisciplina> CursoDisciplinas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // MELHORIA :depois criar um diretorio "Configurations "com classes de configuração para cada entidade
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(entity => 
            {
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.Role).IsRequired().HasMaxLength(20);
            });

            // Relacionamentos 1:1 Usuário -> Roles
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Aluno)
                .WithOne(a => a.Usuario)
                .HasForeignKey<Aluno>(a => a.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Coordenador)
                .WithOne(c => c.Usuario)
                .HasForeignKey<Coordenador>(c => c.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Professor)
                .WithOne(p => p.Usuario)
                .HasForeignKey<Professor>(p => p.UsuarioId);

            // Curso -> Coordenador (1:N)
            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Coordenador)
                .WithMany(c => c.Cursos)
                .HasForeignKey(c => c.CoordenadorId)
                .OnDelete(DeleteBehavior.Restrict);

            // CursoDisciplina (N:N)
            modelBuilder.Entity<CursoDisciplina>()
                .HasKey(cd => new { cd.CursoId, cd.DisciplinaId });

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(cd => cd.Curso)
                .WithMany(c => c.Disciplinas)
                .HasForeignKey(cd => cd.CursoId);

            modelBuilder.Entity<CursoDisciplina>()
                .HasOne(cd => cd.Disciplina)
                .WithMany(d => d.Cursos)
                .HasForeignKey(cd => cd.DisciplinaId);

            // Disciplina -> Professor (N:1)
            modelBuilder.Entity<Disciplina>()
                .HasOne(d => d.Professor)
                .WithMany(p => p.Disciplinas)
                .HasForeignKey(d => d.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            // Matrícula (Aluno + Curso)
            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Aluno)
                .WithMany(a => a.Matriculas)
                .HasForeignKey(m => m.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Matricula>()
                .HasOne(m => m.Curso)
                .WithMany(c => c.Matriculas)
                .HasForeignKey(m => m.CursoId)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuração de Enums
            modelBuilder.Entity<Curso>()
                .Property(c => c.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Matricula>()
                .Property(m => m.Status)
                .HasConversion<string>();

            // Configurações de precisão decimal
            modelBuilder.Entity<Matricula>()
                .Property(m => m.NotaFinal)
                .HasPrecision(4, 2);
        }
    }
}