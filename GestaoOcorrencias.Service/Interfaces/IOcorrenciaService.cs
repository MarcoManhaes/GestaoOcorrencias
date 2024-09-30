using GestaoOcorrencias.Data.Dto;
using GestaoOcorrencias.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Service.Interfaces
{
    public interface IOcorrenciaService : IServicoBase<Ocorrencia>
    {
        Task<IEnumerable<OcorrenciaDto>> GetAllDto();
        Task<OcorrenciaDto> CreateWhitReturnDto(Ocorrencia obj);
        bool ClienteTemOcorrencias(int clienteId);
    }
}
