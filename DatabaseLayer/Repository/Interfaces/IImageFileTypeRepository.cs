using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IImageFileTypeRepository 
    {
        void Add(ImageFileTypeModel entity);
        bool Update(ImageFileTypeModel entity);
        void Remove(ImageFileTypeModel entity);
        bool Exists(Expression<Func<ImageFileTypeModel, bool>> expression);
        IQueryable<ImageFileTypeModel> FindImageFileType(Expression<Func<ImageFileTypeModel, bool>> expression);
        IQueryable<ImageFileTypeModel> GetAllImageFileTypes();
        ImageFileTypeModel GetSingleOrDefaultImageFileType(Expression<Func<ImageFileTypeModel, bool>> expression);
        IQueryable<int> GetAllImageFileUrlsByImageFileTypeId(int ImageFileTypeId);
    }
}
