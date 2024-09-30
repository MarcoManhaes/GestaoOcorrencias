using GestaoOcorrencias.Data;
using GestaoOcorrencias.Data.Dto;
using GestaoOcorrencias.Data.Interfaces;
using GestaoOcorrencias.Data.Models;
using GestaoOcorrencias.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Service.Services
{
    public class OcorrenciaService : IOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        private readonly ApplicationContext _context;

        public OcorrenciaService(IOcorrenciaRepository ocorrenciaRepository, ApplicationContext context)
        {
            _ocorrenciaRepository = ocorrenciaRepository;
            _context = context;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAll()
        {
            return await _ocorrenciaRepository.GetAll();
        }

        public async Task<IEnumerable<OcorrenciaDto>> GetAllDto()
        {
            return await _ocorrenciaRepository.GetAllDto();
        }

        public async Task<Ocorrencia> GetById(int id)
        {
            return await _ocorrenciaRepository.GetById(id);
        }

        public async Task<OcorrenciaDto> CreateWhitReturnDto(Ocorrencia obj)
        {
            return await _ocorrenciaRepository.CreateWhitReturnDto(obj);
        }

        public async Task<Ocorrencia> Create(Ocorrencia obj)
        {
            return await _ocorrenciaRepository.Create(obj);
        }

        public async Task<Ocorrencia> Update(int id, Ocorrencia obj)
        {
            return await _ocorrenciaRepository.Update(id, obj);
        }

        public async Task Delete(int id)
        {
            await _ocorrenciaRepository.Delete(id);
        }

        public bool ClienteTemOcorrencias(int clienteId)
        {
            return _context.Ocorrencias.Any(o => o.ResponsavelAberturaId == clienteId || o.ResponsavelOcorrenciaId == clienteId);
        }
    }
}
