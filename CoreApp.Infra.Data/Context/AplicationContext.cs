using System.Data.Entity.ModelConfiguration.Conventions;
using CoreApp.Infra.Data.Config;
using System;
using System.Data.Entity;
using System.Linq;

namespace CoreApp.Infra.Data.Context
{
    public class AplicationContext : DbContext
    {
        public AplicationContext() : base("DefaultConnection")
        {
            /// Desabilitando o LazyLoading
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new TesteConfig());
            /// Add as configuraçoes das outras Entidades

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            /// Salvando a ultima modificação das Entidades
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("LastModification") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("LastModification").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("LastModification").IsModified = false;
                }
            }

            return base.SaveChanges();
        }
    }
}