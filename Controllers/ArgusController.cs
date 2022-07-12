using ArgusEyesApi.Data;
using ArgusEyesApi.Dtos;
using ArgusEyesApi.Entities;
using ArgusEyesApi.Repositories.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArgusEyesApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArgusController : ControllerBase
    {
        private readonly IkundenDatenRepository kundenDatenRepository;
        public ArgusController(IkundenDatenRepository kundenDatenRepository)
        {
            this.kundenDatenRepository=kundenDatenRepository;
        }
        //private readonly KundenDBContext _kundenDBContext;
        //public ArgusController(KundenDBContext dBContext)
        //{
        //    this._kundenDBContext = dBContext;
        //}

        [HttpGet]
        public IActionResult Get()
        {
            var image = System.IO.File.OpenRead(@"C:\\Users\Omar\source\repos\ArgusEyesApi\wwwroot\Arguseyes\retina.jpg");
            var result = File(image, "image/jpeg");
            return result;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<KundenDatenDto>>> GetAllKdDaten()
        {
            try
            {
                var kdDaten = await this.kundenDatenRepository.GetAllKunden();
                return Ok(kdDaten);
               
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<KundenDatenDto>> GetKdDatenById(int id)
        {
            try
            {
                var kdDaten = await this.kundenDatenRepository.GetKundenById(id);
                return Ok(kdDaten);

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
//https://localhost:7133/api/Argus
//https://localhost:7133/api/Argus/1