using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Repository.Interfaces
{
    public interface IImageFileUrlRepository 
    {
        void Add(ImageFileUrlModel entity);
        bool Update(ImageFileUrlModel entity);
        void Remove(ImageFileUrlModel entity);
        bool Exists(Expression<Func<ImageFileUrlModel, bool>> expression);
        IQueryable<ImageFileUrlModel> FindImageFileUrl(Expression<Func<ImageFileUrlModel, bool>> expression);
        IQueryable<ImageFileUrlModel> GetAllImageFileUrls();
        ImageFileUrlModel GetSingleOrDefaultImageFileUrl(Expression<Func<ImageFileUrlModel, bool>> expression);
    }
}
