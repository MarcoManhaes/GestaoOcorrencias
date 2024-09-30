using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Data.Models
{
    public class Ocorrencia : EntityBase
    {
        public DateTime DataAbertura { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public string Conclusao { get; set; }


        public int ResponsavelAberturaId { get; set; }
        public virtual Cliente ResponsavelAbertura { get; set; }

        public int ResponsavelOcorrenciaId { get; set; }
        public virtual Cliente ResponsavelOcorrencia { get; set; }
    }
}
