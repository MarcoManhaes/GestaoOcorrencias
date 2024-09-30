using System;
using System.IO;

namespace GestaoOcorrencias.Data.Configurations
{
    public static class ConnectionStringConfiguration
    {
        private static readonly string AppNome = "GestaoOcorrencias.Application";
        private static readonly string AppCaminho = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), AppNome);

        public static string ObterConnectionString()
        {
            EnsureFolderExists(AppCaminho);
            return $"Data Source={AppCaminho}\\gestao-ocorrencia_db.sqlite";
        }

        private static string EnsureFolderExists(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            return folderPath;
        }
    }
}
