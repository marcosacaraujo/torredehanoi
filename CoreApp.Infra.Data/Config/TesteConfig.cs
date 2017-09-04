using CoreApp.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace CoreApp.Infra.Data.Config
{
    public class TesteConfig : EntityTypeConfiguration<Teste>
    {
        public TesteConfig()
        {
            HasKey(t => t.TesteId).Property(t => t.TesteId).HasColumnName("id_teste").IsRequired();
            Property(t => t.LastModification).HasColumnName("data_cadastro");
            ToTable("db_teste");
        }
    }
}