using ArgusEyesApi.Data;
using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ArgusEyesApi.Repositories
{
    public class MetadatenRepository : IMetadatenRepository
    {
        private readonly KundenDBContext _kundenDBContext;
        public MetadatenRepository(KundenDBContext kundenDBContext)
        {
            this._kundenDBContext= kundenDBContext;

        }

        public async Task<IEnumerable<Metadaten>> GetAllImagesMetaDaten()
        {
            var kdDaten = await this._kundenDBContext.Metadaten.ToListAsync();
            return kdDaten;
        }
        
        public async Task<Metadaten> GetImageMetaDatenById(int id)
        {
            var kdDaten = await _kundenDBContext.Metadaten.FindAsync(id);
            //return new Metadaten
            //{
            //    Id = id,

            //};
            //var test = await (from KdImageId in _kundenDBContext.KundenImagesDaten
            //                  where KdImageId.Id == id
            //                  select KdImageId).Find();
            return kdDaten;


            //var kundenImages = _kundenDBContext.KundenImagesDaten.FirstOrDefault(x =>x.Id == id);
            //Metadaten metadaten = new Metadaten();
            //metadaten.Id= kundenImagesMetaDatenDto.Id;
            //return kundenImages;

            //var kdDaten = await this._kundenDBContext.Metadaten.FindAsync(id);
            //KundenImagesDaten imagesDaten = new KundenImagesDaten();
            //imagesDaten.MetadatenId = id;
            //return imagesDaten;
        }

        public async Task<bool> AddImageMetaDaten(KundenImagesMetaDatenDto dto)
        {
            
            try
            {
                // hole Bild aus der db 
                var kd = await _kundenDBContext.KundenImagesDaten.Include(x => x.Metadaten).Where(x => x.Id == dto.Id).FirstOrDefaultAsync();
                if (kd != null)
                {
                   
                    if (kd.Metadaten != null)
                    {
                        kd.Metadaten.Helligkeit = dto.HelligkeitDto;
                        kd.Metadaten.Kontrast = dto.KontrastDto;
                        _kundenDBContext.Metadaten.Update(kd.Metadaten);
                    }
                    else
                    {
                        Metadaten metaDatenRecord = new();
                        metaDatenRecord.Helligkeit = dto.HelligkeitDto;
                        metaDatenRecord.Kontrast = dto.KontrastDto;
                        kd.Metadaten = metaDatenRecord;
                        _kundenDBContext.KundenImagesDaten.Update(kd);
                    }
                    int changes = await _kundenDBContext.SaveChangesAsync();

                    if (changes > 0)
                        return true;
                    else
                        return false;
                }
                else
                {
                    return false;
                }


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return false;
        }


    }
}
