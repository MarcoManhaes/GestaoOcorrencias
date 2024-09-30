using GestaoOcorrencias.Data.Dto;
using GestaoOcorrencias.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Data.Interfaces
{
    public interface IOcorrenciaRepository : IRepositoryBase<Ocorrencia>
    {
        Task<IEnumerable<OcorrenciaDto>> GetAllDto();
        Task<OcorrenciaDto> CreateWhitReturnDto(Ocorrencia obj);
    }
}
