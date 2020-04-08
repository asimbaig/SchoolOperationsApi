using DatabaseLayer.Models;
using DTOs;
using SchoolOperationsApi.Common;
using ServiceLayer.Implementations;
using ServiceLayer.Interfaces;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace SchoolOperationsApi.Controllers
{
    [Authorize]
    public class ImageFileUrlController : BaseController
    {
        private readonly IImageFileUrlService ImageFileUrlService;

        //Constructor
        public ImageFileUrlController()
        {
            this.ImageFileUrlService = new ImageFileUrlService();
        }

        // GET: api/ImageFileUrl/All
        [CustomExceptionFilter]
        [Route("api/ImageFileUrl/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllImageFileUrls()
        {
            var collection = await (ImageFileUrlService.GetAllImageFileUrl());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/ImageFileUrl/5
        [ResponseType(typeof(ImageFileUrlModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetImageFileUrl(int id)
        {
            ImageFileUrlDTO dto = await ImageFileUrlService.SearchSingleImageFileUrlByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/ImageFileUrl/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/ImageFileUrl/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddImageFileUrl([FromBody]ImageFileUrlDTO ImageFileUrlModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newImageFileUrlId = await ImageFileUrlService.AddImageFileUrlAsync(ImageFileUrlModel);

            if (newImageFileUrlId != 0)
                return Ok(newImageFileUrlId);
            else
                return NotFound();
        }

        // PUT: api/ImageFileUrl/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/ImageFileUrl/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateImageFileUrl([FromBody]ImageFileUrlDTO ImageFileUrlModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedImageFileUrl = await ImageFileUrlService.UpdateImageFileUrlAsync(ImageFileUrlModel);

            if (updatedImageFileUrl != null)
                return Ok(updatedImageFileUrl);
            else
                return NotFound();
        }

        // DELETE: api/ImageFileUrl/{id}
        [ResponseType(typeof(ImageFileUrlModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteImageFileUrl(int id)
        {
            var Id = await ImageFileUrlService.RemoveImageFileUrlAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool ImageFileUrlModelExists(int id)
        {
            return ImageFileUrlService.IsImageFileUrlExistsById(id);
        }

    }
}