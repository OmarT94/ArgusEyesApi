using ArgusEyesApi.Data;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArgusEyesApi.Repositories
{
    public class KundenDatenRepository : IkundenDatenRepository
    {
        private readonly KundenDBContext kundenDBContext;
        public KundenDatenRepository(KundenDBContext kundenDBContext)
        {
            this.kundenDBContext= kundenDBContext;
        }

        public async Task<IEnumerable<KundenDaten>> GetAllKunden()
        {
            var kdDaten = await kundenDBContext.KundenDaten.ToListAsync();
            return kdDaten;
        }

        public async Task<KundenDaten> GetKundenById(int id)
        {
            var kdDaten = await kundenDBContext.KundenDaten.FindAsync(id);
            return kdDaten;
        }
    }
}
