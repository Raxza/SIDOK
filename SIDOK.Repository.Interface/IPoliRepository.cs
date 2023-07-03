using SIDOK.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIDOK.Repository.Interface
{
    public interface IPoliRepository
    {
        Task<IEnumerable<Poli>> GetAllPoli();
        Task<PoliForDetails> GetPoliDetails(int id);
        Task<Poli> GetPoli(int id);
        Task CreatePoli(PoliForCreateDto poli);
        Task UpdatePoli(int id, PoliForCreateDto poli);
        Task DeletePoli(int id);
    }
}
