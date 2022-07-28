using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArgusEyesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetaDatenController : ControllerBase
    {
        private readonly IMetadatenRepository _metadatenRepository;
        public MetaDatenController(IMetadatenRepository metadatenRepository)
        {
            this._metadatenRepository=metadatenRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<KundenImagesMetaDatenDto>> GetKundenImagesMetaDatenById(int id)
        {
            try
            {
                var kdDaten = await this._metadatenRepository.GetImageMetaDatenById(id);
                KundenImagesDaten imagesDaten = new();
                imagesDaten.MetadatenId = id;
                //KundenImagesMetaDatenDto kundenImagesMetaDatenDto = new();
                //kundenImagesMetaDatenDto.HelligkeitDto = imagesDaten.Metadaten.Helligkeit;
                return Ok(kdDaten);


            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<KundenImagesMetaDatenDto>> PostKundenImagesMetaDatenById(KundenImagesMetaDatenDto dto)
        {
            //var kdDaten = this._metadatenRepository.GetImageMetaDatenById 
            //Metadaten metadaten = new();
            //metadaten.Id = kundenImagesMetaDatenDto.Id;
            //KundenImagesDaten dtoo = new();
           
            return Ok(await _metadatenRepository.AddImageMetaDaten( dto));
        }


    }
}
