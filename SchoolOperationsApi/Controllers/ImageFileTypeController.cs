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
    public class ImageFileTypeController : BaseController
    {
        private readonly IImageFileTypeService ImageFileTypeService;

        //Constructor
        public ImageFileTypeController()
        {
            this.ImageFileTypeService = new ImageFileTypeService();
        }

        // GET: api/ImageFileType/All
        [CustomExceptionFilter]
        [Route("api/ImageFileType/All")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllImageFileTypes()
        {
            var collection = await (ImageFileTypeService.GetAllImageFileType());

            if (collection != null)
                return Ok(collection);
            else
                return NotFound();
        }

        // GET: api/ImageFileType/5
        [ResponseType(typeof(ImageFileTypeModel))]
        [CustomExceptionFilter]
        [HttpGet]
        public async Task<IHttpActionResult> GetImageFileType(int id)
        {
            ImageFileTypeDTO dto = await ImageFileTypeService.SearchSingleImageFileTypeByIdAsync(id);

            if (dto != null)
                return Ok(dto);
            else
                return NotFound();
        }

        // Post: api/ImageFileType/Add
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/ImageFileType/Add")]
        [HttpPost]
        public async Task<IHttpActionResult> AddImageFileType([FromBody]ImageFileTypeDTO ImageFileTypeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newImageFileTypeId = await ImageFileTypeService.AddImageFileTypeAsync(ImageFileTypeModel);

            if (newImageFileTypeId != 0)
                return Ok(newImageFileTypeId);
            else
                return NotFound();
        }

        // PUT: api/ImageFileType/Update
        [ResponseType(typeof(void))]
        [CustomExceptionFilter]
        [Route("api/ImageFileType/Update")]
        [HttpPut]
        public async Task<IHttpActionResult> UpdateImageFileType([FromBody]ImageFileTypeDTO ImageFileTypeModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedImageFileType = await ImageFileTypeService.UpdateImageFileTypeAsync(ImageFileTypeModel);

            if (updatedImageFileType != null)
                return Ok(updatedImageFileType);
            else
                return NotFound();
        }

        // DELETE: api/ImageFileType/{id}
        [ResponseType(typeof(ImageFileTypeModel))]
        [HttpDelete]
        public async Task<IHttpActionResult> DeleteImageFileType(int id)
        {
            var Id = await ImageFileTypeService.RemoveImageFileTypeAsync(id);

            if (Id != 0)
                return Ok(Id);
            else
                return NotFound();
        }

        private bool ImageFileTypeModelExists(int id)
        {
            return ImageFileTypeService.IsImageFileTypeExistsById(id);
        }

    }
}