using System;
using System.Data.Entity;
using System.Linq;
using TimeSheet.Entity.Map;
using TimeSheet.Modelo;

namespace TimeSheet.Entity.Contexto
{
    public class TimeSheetDataContext : DbContext
    {
        public TimeSheetDataContext() : base("TimeSheetDB")
        {
        }

        public DbSet<Marcacao> Marcacao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new MarcacaoMap());
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataAlteracao") != null))
            {
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataAlteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }

    }
}
