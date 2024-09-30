using FluentMigrator.Runner;
using FluentMigrator.Runner.Announcers;
using FluentMigrator.Runner.Initialization;
using FluentMigrator.Runner.Processors;
using FluentMigrator.Runner.Processors.SQLite;
using GestaoOcorrencias.Data.Configurations;
using GestaoOcorrencias.Data.Migrations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoOcorrenciasApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ExecuteMigration();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        static void ExecuteMigration()
        {
            Console.WriteLine("Criando o registro de mensagens de migração...");
            var announcer = new ConsoleAnnouncer();

            Console.WriteLine("Opções específicas do processador (geralmente nenhuma é necessária)...");
            var options = new ProcessorOptions();

            Console.WriteLine("Usando SQLite...");
            var processorFactory = new SQLiteProcessorFactory();

            Console.WriteLine("Obtendo a ConnectionString...");
            var connectionString = ConnectionStringConfiguration.ObterConnectionString();

            Console.WriteLine("Inicializando o processador...");
            using (var processor = processorFactory.Create(
                connectionString,
                announcer,
                options))
            {
                Console.WriteLine("Configurando o runner...");
                var context = new RunnerContext(announcer);

                Console.WriteLine("Criando o runner de migrações...");
                Console.WriteLine("Especificando o assembly com as migrações...");
                var runner = new MigrationRunner(
                    typeof(Initial_Migration).Assembly,
                    context,
                    processor);

                try
                {
                    Console.WriteLine("Executando as migrações...");
                    runner.MigrateUp();
                    Console.WriteLine("Migração concluída com sucesso.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro durante a migração: {ex.Message}");
                }
            }
        }
    }
}
