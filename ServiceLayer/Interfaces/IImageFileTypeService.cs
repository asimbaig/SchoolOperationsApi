using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IImageFileTypeService
    {
        Task<int> AddImageFileTypeAsync(ImageFileTypeDTO model);
        Task<ImageFileTypeDTO> UpdateImageFileTypeAsync(ImageFileTypeDTO model);
        Task<int> RemoveImageFileTypeAsync(int ImageFileTypeId);
        Task<List<ImageFileTypeDTO>> GetAllImageFileType();
        Task<ImageFileTypeDTO> SearchSingleImageFileTypeByTypeAsync(string term);
        bool IsImageFileTypeExistsById(int ImageFileTypeId);
        List<ImageFileTypeDTO> SearchImageFileTypesByTypeAsync(string term);
        Task<ImageFileTypeDTO> SearchSingleImageFileTypeByIdAsync(int Id);
    }
}
