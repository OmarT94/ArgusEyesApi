using ArgusEyesApi.Data;
using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Helper;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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

        public async Task<FileContentResult> PostKundenImage(string path, string name)
        {
            try
            {
                FileStream image = System.IO.File.OpenRead(path);
                byte[] array = ImageHelper.ToByteArray(image);
                FileContentResult result = new FileContentResult(array, "image/jpeg");

                //Speichere den byte[] in der datenbank
                KundenImagesDaten bild = new KundenImagesDaten();
                bild.Content=array;
                bild.Name = name;
               
                await _kundenDBContext.KundenImagesDaten.AddAsync(bild);
                await _kundenDBContext.SaveChangesAsync();

                return result;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                
            }
            return null;
        }
        
    }
}
