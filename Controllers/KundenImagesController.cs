using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgusEyesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KundenImagesController : ControllerBase
    {
        private readonly IImageFileRepository _imageFileRepository;
        public KundenImagesController(IImageFileRepository imageFileRepository)
        {
            this._imageFileRepository = imageFileRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<KundenDatenImagesDto>>> GetAllKundenImages()
        {
            try
            {
                var kdDaten = await this._imageFileRepository.GetAllKundenImages();
                return Ok(kdDaten);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<KundenDatenImagesDto>> GetKundenImageById(int id)
        {
            try
            {
                var kdDaten = await this._imageFileRepository.GetKundenImageById(id);
                //var base64 = "data:image/png;base64,"+ System.Convert.ToBase64String(kdDaten.Content);
                KundenDatenImagesDto a = new KundenDatenImagesDto();
                a.FileName = kdDaten.Name;
                a.ContentFile = kdDaten.Content;
               KundenImagesMetaDatenDto dto = new KundenImagesMetaDatenDto();
                dto.HelligkeitDto = (int)kdDaten.Metadaten.Helligkeit;
                dto.KontrastDto = (int)kdDaten.Metadaten.Kontrast;
                
                return Ok(a);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        //https://localhost:7133/api/KundenImages/GetKundenImageById/1


        [HttpPost("PostKundenImageById")]
        public async Task<ActionResult> PostKundenImageById(ImageDto dto)
        {
            try
            {
                return Ok(await _imageFileRepository.PostKundenImage(dto.ImagePath, dto.Name));

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
