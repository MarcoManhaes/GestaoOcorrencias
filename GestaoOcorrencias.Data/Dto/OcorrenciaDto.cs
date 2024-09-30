using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Data.Dto
{
    public class OcorrenciaDto
    {
        public int Id { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataOcorrencia { get; set; }
        public string Descricao { get; set; }
        public string Conclusao { get; set; }
        public int ResponsavelAberturaId { get; set; }
        public int ResponsavelOcorrenciaId { get; set; }
        public string ResponsavelAberturaNome { get; set; }
        public string ResponsavelOcorrenciaNome { get; set; }
    }
}
