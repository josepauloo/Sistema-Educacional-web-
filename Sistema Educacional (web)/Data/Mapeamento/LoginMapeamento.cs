using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sistema_Educacional__web_.Models;

namespace Sistema_Educacional__web_.Data.Mapeamento
{
    public class LoginMapeamento : IEntityTypeConfiguration<Login>
    {
        public void Configure(EntityTypeBuilder<Login> builder)
        {
            builder.ToTable("Aluno");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Email).HasColumnType("varchar(100)");

            builder.Property(t => t.Senha).HasColumnType("varchar(100)");

        }
    }
}
