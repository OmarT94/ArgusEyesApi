using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;

namespace ArgusEyesApi.Repositories.Contracts
{
    public interface IPunktKoordinatenRepository
    {
        Task<IEnumerable<PunktKoordinaten>> GetAllImagesPunktKoordinaten();
        Task <PunktKoordinaten> GetImagesPunktKoordinatenById (int id);

        Task<bool> AddImagesPunktKoordinaten(int ImageKoordinatId, KundenImagesMetaDatenDto kundenImagesMetaDatenDto);
    }
}
