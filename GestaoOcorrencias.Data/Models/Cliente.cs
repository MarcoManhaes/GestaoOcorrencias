using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Data.Models
{
    public class Cliente : EntityBase
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        // Relacionamento: um cliente pode estar relacionado a várias ocorrências
        public virtual ICollection<Ocorrencia> OcorrenciasAbertas { get; set; }
        public virtual ICollection<Ocorrencia> OcorrenciasResponsavel { get; set; }
    }
}
