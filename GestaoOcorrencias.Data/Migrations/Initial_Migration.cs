using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Data.Migrations
{
    [Migration(1)]
    public class Initial_Migration : Migration
    {
        public override void Up()
        {
            #region[+] Processo
            string sqlCliente = @"CREATE TABLE Cliente (
                                    Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                                    Nome VARCHAR(150) NOT NULL,
                                    Endereco VARCHAR(255),
                                    Telefone VARCHAR(25),
                                    Email VARCHAR(150)
                                 );";
            #endregion

            #region[+] Movimentacao
            string sqlOcorrencia = @"CREATE TABLE Ocorrencia (
                                        Id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
                                        DataAbertura DATETIME NOT NULL,
                                        DataOcorrencia DATETIME NOT NULL,
                                        Descricao VARCHAR(255),
                                        Conclusao VARCHAR(255),
                                        ResponsavelAberturaId INTEGER NOT NULL,
                                        ResponsavelOcorrenciaId INTEGER NOT NULL,
                                        FOREIGN KEY (ResponsavelAberturaId) REFERENCES Cliente(Id) ON DELETE CASCADE,
                                        FOREIGN KEY (ResponsavelOcorrenciaId) REFERENCES Cliente(Id) ON DELETE CASCADE
                                    );";
            #endregion

            #region[+] Execute
            Execute.Sql(sqlCliente);
            Execute.Sql(sqlOcorrencia);
            #endregion

            #region[+] Carga inicial de dados - Clientes
            string sqlInsertClientes = @"INSERT INTO Cliente (Nome, Endereco, Telefone, Email) 
                                         VALUES 
                                         ('Cliente 1', 'Rua Exemplo 123', '31 1111-1111', 'cliente1@exemplo.com'),
                                         ('Cliente 2', 'Avenida Exemplo 456', '11 2222-2222', 'cliente2@exemplo.com');";
            Execute.Sql(sqlInsertClientes);
            #endregion
        }

        public override void Down()
        {
            #region[+] Downgrade
            Delete.Table("Cliente");
            Delete.Table("Ocorrencia");
            #endregion
        }
    }
}
