using GestaoOcorrencias.Data.Configurations;
using System;
using System.Data.Common;
using System.Data.Entity;
using System.Data.SQLite;
using System.Data.Entity.Core.Common;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite.EF6;
using GestaoOcorrencias.Data.Models;

namespace GestaoOcorrencias.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base(CreateConnection(), true)
        {
            DbConfiguration.SetConfiguration(new SQLiteConfiguration());
            Database.SetInitializer<ApplicationContext>(null);
        }

        private static DbConnection CreateConnection()
        {
            string connectionString = ConnectionStringConfiguration.ObterConnectionString();

            return new SQLiteConnection(connectionString);
        }

        public class SQLiteConfiguration : DbConfiguration
        {
            public SQLiteConfiguration()
            {
                SetProviderFactory("System.Data.SQLite", SQLiteFactory.Instance);
                SetProviderFactory("System.Data.SQLite.EF6", SQLiteProviderFactory.Instance);
                SetProviderServices("System.Data.SQLite", (DbProviderServices)SQLiteProviderFactory.Instance.GetService(typeof(DbProviderServices)));
            }
        }

        public bool Commit()
        {
            try
            {
                lock (this)
                {
                    return this.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ocorrencia> Ocorrencias { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            this.Configuration.LazyLoadingEnabled = false;

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<Ocorrencia>()
                 .HasRequired(o => o.ResponsavelAbertura)
                 .WithMany(c => c.OcorrenciasAbertas)
                 .HasForeignKey(o => o.ResponsavelAberturaId)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ocorrencia>()
                .HasRequired(o => o.ResponsavelOcorrencia)
                .WithMany(c => c.OcorrenciasResponsavel)
                .HasForeignKey(o => o.ResponsavelOcorrenciaId)
                .WillCascadeOnDelete(false);
        }
    }
}
