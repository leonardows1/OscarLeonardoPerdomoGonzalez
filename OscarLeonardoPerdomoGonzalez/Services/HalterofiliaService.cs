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

        public async Task<Halterofilia> RegistrarHalteroofilia(CreateHalterofiliaDTO createHalterofiliaDTO)
        {
            Halterofilia halterofilia = new()
            {
                Pais = createHalterofiliaDTO.Pais,
                DeportistaId = createHalterofiliaDTO.DeportistaId,
                ArranqueKg = createHalterofiliaDTO.ArranqueKg,
                EnvionKg = createHalterofiliaDTO.EnvionKg,
                TotalPeso = createHalterofiliaDTO.TotalPeso
            };
            await _context.Halterofilias.AddAsync(halterofilia);
            return await _context.Halterofilias.SingleOrDefaultAsync(h => h.HalterofiliaId == halterofilia.HalterofiliaId);
        }
    }

    public interface IHalterofiliaService
    {
        Task<IEnumerable<Halterofilia>> GetTableroHalterofilias();
    }
}
