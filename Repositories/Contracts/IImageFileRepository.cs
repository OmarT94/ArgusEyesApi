using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ArgusEyesApi.Repositories.Contracts
{
    public interface IImageFileRepository
    {
        Task<IEnumerable<KundenImagesDaten>> GetAllKundenImages();
        Task<KundenImagesDaten> GetKundenImageById(int id);
        Task<FileContentResult> PostKundenImage(string path , string name);
    }
}
