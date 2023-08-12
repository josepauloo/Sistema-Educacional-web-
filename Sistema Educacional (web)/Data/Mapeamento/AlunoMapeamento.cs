using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sistema_Educacional__web_.Models;

namespace Sistema_Educacional__web_.Data.Mapeamento
{
    public class AlunoMapeamento : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Nome).HasColumnType("varchar(100)");

            builder.Property(t => t.Idade).HasColumnType("int");
            
            builder.Property(t => t.Matrícula).HasColumnType("varchar(100)");
            
            builder.Property(t => t.Nota).HasColumnType("decimal");
            
            builder.Property(t => t.Cep).HasColumnType("varchar(100)");

        }
    }
}
