using ArgusEyesApi.Data;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArgusEyesApi.Repositories
{
    public class ImageFileRepository : IImageFileRepository
    {

        private readonly KundenDBContext _kundenDBContext;
        public ImageFileRepository(KundenDBContext kundenDBContext)
        {
            this._kundenDBContext = kundenDBContext;
        }
        public  async Task<IEnumerable<KundenImagesDaten>> GetAllKundenImages()
        {
            var kdDaten = await _kundenDBContext.KundenImagesDaten.ToListAsync();
            return kdDaten;
        }

        public async Task <KundenImagesDaten> GetKundenImageById(int id)
        {
            //hole das Bild 
            var kdDaten = await _kundenDBContext.KundenImagesDaten.FindAsync(id);

            // Checke ob es Metadaten gibt 
            if (kdDaten.MetadatenId != null)
            {
                //Hole die Metadaten 
                var metaDaten = await _kundenDBContext.Metadaten.FindAsync(kdDaten.MetadatenId);

                // Wenn es Metadaten gibt, füge sie zu dem Bild 
                if (metaDaten != null)
                {
                    kdDaten.Metadaten = metaDaten;
                }
            }
            return kdDaten;
        }
    }
}
