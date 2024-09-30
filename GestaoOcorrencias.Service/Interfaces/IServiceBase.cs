using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestaoOcorrencias.Service.Interfaces
{
    public interface IServicoBase<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<T> Create(T obj);
        Task<T> Update(int id, T obj);
        Task Delete(int id);
    }
}
