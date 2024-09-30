using GestaoOcorrencias.Data.Dto;
using GestaoOcorrencias.Data.Interfaces;
using GestaoOcorrencias.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Data.Repositories
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly ApplicationContext _context;

        public OcorrenciaRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ocorrencia>> GetAll()
        {
            try
            {
                var ocorrencias = await _context.Ocorrencias.AsNoTracking().ToListAsync();
                return ocorrencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<OcorrenciaDto>> GetAllDto()
        {
            try
            {
                var ocorrencias = await _context.Ocorrencias.AsNoTracking()
                    .Include(o => o.ResponsavelAbertura)
                    .Include(o => o.ResponsavelOcorrencia)
                    .Select(o => new OcorrenciaDto
                    {
                        Id = o.Id,
                        DataAbertura = o.DataAbertura,
                        DataOcorrencia = o.DataOcorrencia,
                        Descricao = o.Descricao,
                        Conclusao = o.Conclusao,
                        ResponsavelAberturaId = o.ResponsavelAberturaId,
                        ResponsavelOcorrenciaId = o.ResponsavelOcorrenciaId,
                        ResponsavelAberturaNome = o.ResponsavelAbertura.Nome,
                        ResponsavelOcorrenciaNome = o.ResponsavelOcorrencia.Nome
                    }).AsNoTracking().ToListAsync();

                return ocorrencias;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Ocorrencia> GetById(int id)
        {
            var ocorrencia = await _context.Ocorrencias.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return ocorrencia;
        }

        public async Task<Ocorrencia> Create(Ocorrencia obj)
        {
            try
            {
                _context.Ocorrencias.Add(obj);

                if (!_context.Commit())
                {
                    throw new Exception("Erro ao incluir a ocorrência.");
                }

                return obj; 
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao incluir a ocorrência: " + ex.Message);
            }
        }

        public async Task<OcorrenciaDto> CreateWhitReturnDto(Ocorrencia obj)
        {
            try
            {
                _context.Ocorrencias.Add(obj);

                if (!_context.Commit())
                {
                    throw new Exception("Erro ao incluir a ocorrência.");
                }


                var ocorrencia = await _context.Ocorrencias
                    .Include(o => o.ResponsavelAbertura)
                    .Include(o => o.ResponsavelOcorrencia)
                    .Select(o => new OcorrenciaDto
                    {
                        Id = o.Id,
                        DataAbertura = o.DataAbertura,
                        DataOcorrencia = o.DataOcorrencia,
                        Descricao = o.Descricao,
                        Conclusao = o.Conclusao,
                        ResponsavelAberturaId = o.ResponsavelAberturaId,
                        ResponsavelOcorrenciaId = o.ResponsavelOcorrenciaId,
                        ResponsavelAberturaNome = o.ResponsavelAbertura.Nome,
                        ResponsavelOcorrenciaNome = o.ResponsavelOcorrencia.Nome
                    }).AsNoTracking().FirstOrDefaultAsync(x => x.Id == obj.Id);

                return ocorrencia;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao incluir a ocorrência: " + ex.Message);
            }
        }

        public async Task<Ocorrencia> Update(int id, Ocorrencia obj)
        {
            try
            {
                var ocorrenciaExistente = await _context.Ocorrencias.FindAsync(id);
                if (ocorrenciaExistente == null)
                {
                    throw new KeyNotFoundException($"Ocorrência com ID {id} não encontrada.");
                }

                ocorrenciaExistente.Conclusao= obj.Conclusao;
                ocorrenciaExistente.DataAbertura = obj.DataAbertura;
                ocorrenciaExistente.DataOcorrencia = obj.DataOcorrencia;
                ocorrenciaExistente.Descricao = obj.Descricao;
                ocorrenciaExistente.ResponsavelAberturaId = obj.ResponsavelAberturaId;
                ocorrenciaExistente.ResponsavelOcorrenciaId = obj.ResponsavelOcorrenciaId;

                await _context.SaveChangesAsync();

                return ocorrenciaExistente;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o ocorrência: " + ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            var empresaParaRemocao = await _context.Ocorrencias.FindAsync(id);
            _context.Ocorrencias.Remove(empresaParaRemocao);
            await _context.SaveChangesAsync();
        }
    }
}
