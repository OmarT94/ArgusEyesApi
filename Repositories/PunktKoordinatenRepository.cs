using ArgusEyesApi.Data;
using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace ArgusEyesApi.Repositories
{
    public class PunktKoordinatenRepository : IPunktKoordinatenRepository
    {
        private readonly KundenDBContext _kundenDBContext;
        public PunktKoordinatenRepository(KundenDBContext kundenDBContext)
        {
            this._kundenDBContext = kundenDBContext;
        }

        public async Task<IEnumerable<PunktKoordinaten>> GetAllImagesPunktKoordinaten()
        {
            var kdDaten = await _kundenDBContext.PunktKoordinaten.ToListAsync();
            return kdDaten;
        }

        public async Task<PunktKoordinaten> GetImagesPunktKoordinatenById(int id)
        {
            var kdDaten = await _kundenDBContext.PunktKoordinaten.FindAsync(id);
            return kdDaten;
        }

        public async Task<bool> AddImagesPunktKoordinaten(int ImageKoordinatId, KundenImagesMetaDatenDto kundenImagesMetaDatenDto)
        {
            PunktKoordinaten punktKoordinatenRecord = new();
            punktKoordinatenRecord.X = kundenImagesMetaDatenDto.XDto;
            punktKoordinatenRecord.Y = kundenImagesMetaDatenDto.YDto;
            punktKoordinatenRecord.Text = kundenImagesMetaDatenDto.TextDto;

            try
            {
                // hole Bild aus der db 
                var kd = await _kundenDBContext.KundenImagesDaten.FindAsync(ImageKoordinatId);
                if (kd != null)
                {
                    // füge die metadaten dem Bild zu 
                    kd.PunktKoordinaten = punktKoordinatenRecord;
                }
                else
                {
                    return false;
                }

                _kundenDBContext.KundenImagesDaten.Update(kd);
                int changes = await _kundenDBContext.SaveChangesAsync();

                if (changes > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {

            }
            return false;
        }
    }
}
