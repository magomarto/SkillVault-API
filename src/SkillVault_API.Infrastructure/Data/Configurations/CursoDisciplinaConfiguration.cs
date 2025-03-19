using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SkillVault_API.Core.Entities;

namespace SkillVault_API.Infrastructure.Data.Configurations
{
    public class CursoDisciplinaConfiguration : IEntityTypeConfiguration<CursoDisciplina>
    {
        public void Configure(EntityTypeBuilder<CursoDisciplina> builder)
        {


        }
    }
}