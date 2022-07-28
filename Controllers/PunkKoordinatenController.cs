using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgusEyesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PunkKoordinatenController : ControllerBase
    {
        private readonly IPunktKoordinatenRepository _punktKoordinatenRepository;
        public PunkKoordinatenController(IPunktKoordinatenRepository punktKoordinatenRepository)
        {
            this._punktKoordinatenRepository = punktKoordinatenRepository;
        }

        [HttpGet("{id}")]
        public async Task <ActionResult<KundenImagesMetaDatenDto>> GetKundenImagesKoordinaten(int id)
        {
            try
            {
                var kdDaten = await this._punktKoordinatenRepository.GetImagesPunktKoordinatenById(id);
                KundenImagesDaten imagesDaten = new();
                imagesDaten.PunktKoordinatenId = id;
                return Ok(imagesDaten);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task <ActionResult<KundenImagesMetaDatenDto>> PostImagesKoordinaten(int imageKoordinat,KundenImagesMetaDatenDto dto)
        {
            return Ok(await this._punktKoordinatenRepository.AddImagesPunktKoordinaten(imageKoordinat, dto));
        }

    }
    
}
