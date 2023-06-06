using Microsoft.EntityFrameworkCore;
using OscarLeonardoPerdomoGonzalez.Models;

namespace OscarLeonardoPerdomoGonzalez.Services
{
    public class HalterofiliaService : IHalterofiliaService
    {
        private readonly HalterofiliaContext _context;

        public HalterofiliaService(HalterofiliaContext context) => _context = context;

        public async Task<IEnumerable<Halterofilia>> GetTableroHalterofilias()
        {
            return await _context.Halterofilias.OrderByDescending(h => h.TotalPeso).ToListAsync();
        }
    }

    public interface IHalterofiliaService
    {
        Task<IEnumerable<Halterofilia>> GetTableroHalterofilias();
    }
}
