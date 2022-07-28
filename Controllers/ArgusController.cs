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

        //[HttpGet]
        //public IActionResult watchPost(int IdPost)
        //{
        //    ContentForoModel forum = new ContentForoModel();//this model is used to "join" various
        //                                                    //models

        //    //get the data from the different tables with the id sending from the MVC controller
        //    var appfile = _imageDBContext.AppFiles.Where(x => x.Id == IdPost).FirstOrDefault();

        //    //Content data from the post

        //    forum.Content = appfile.Name;//the text part
        //    forum.ContentFile = appfile.Content;//the image

        //    return Ok(forum);
        //}

    }
}
//https://localhost:7133/api/Argus
//https://localhost:7133/api/Argus/1