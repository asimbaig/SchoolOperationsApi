using DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces
{
    public interface IImageFileUrlService
    {
        Task<int> AddImageFileUrlAsync(ImageFileUrlDTO model);
        Task<ImageFileUrlDTO> UpdateImageFileUrlAsync(ImageFileUrlDTO model);
        Task<int> RemoveImageFileUrlAsync(int ImageFileUrlId);
        Task<List<ImageFileUrlDTO>> GetAllImageFileUrl();
        Task<ImageFileUrlDTO> SearchSingleImageFileUrlByUrlAsync(string term);
        bool IsImageFileUrlExistsById(int ImageFileUrlId);
        List<ImageFileUrlDTO> SearchImageFileUrlsByUrlAsync(string term);
        Task<ImageFileUrlDTO> SearchSingleImageFileUrlByIdAsync(int Id);
    }
}
