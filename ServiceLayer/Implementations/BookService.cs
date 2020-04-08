using DatabaseLayer.Models;
using DTOs;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Implementations
{
    public class BookService : BaseService, IBookService
    {
        public BookService() : base()
        {
            SetAutoMapper_Book();
        }

        //Add Book (async)
        public async Task<int> AddBookAsync(BookDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("BookImage"));

                        ImageFileTypeDTO imageFileTypeDTO = _Mapper_ToDTO.Map<ImageFileTypeModel, ImageFileTypeDTO>(tempImageTypeModel);

                        modelDTO.ImageFileUrl = new ImageFileUrlDTO()
                        {
                            Url = modelDTO._ImageFileUrl,
                            CreateDate = DateTime.Now,
                            ImageFileTypeId = imageFileTypeDTO.ImageFileTypeId
                        };
                    }
                    else
                    {
                        modelDTO.ImageFileUrl = null;
                    }

                    BookModel model = _Mapper_ToModel.Map<BookDTO, BookModel>(modelDTO);

                    unitOfWork.BookRepository.Add(model);
                    //unitOfWork.Repository.Add<BookModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.BookId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update Book (async)
        public async Task<BookDTO> UpdateBookAsync(BookDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    if (!string.IsNullOrEmpty(modelDTO._ImageFileUrl))
                    {
                        var tempImageTypeModel = unitOfWork.ImageFileTypeRepository.GetSingleOrDefaultImageFileType(x => x.Type.Contains("BookImage"));

                        ImageFileTypeDTO imageFileTypeDTO = _Mapper_ToDTO.Map<ImageFileTypeModel, ImageFileTypeDTO>(tempImageTypeModel);

                        modelDTO.ImageFileUrl = new ImageFileUrlDTO()
                        {
                            Url = modelDTO._ImageFileUrl,
                            CreateDate = DateTime.Now,
                            ImageFileTypeId = imageFileTypeDTO.ImageFileTypeId
                        };
                    }
                    else
                    {
                        modelDTO.ImageFileUrl = null;
                    }

                    BookModel model = _Mapper_ToModel.Map<BookDTO, BookModel>(modelDTO);

                    bool result = unitOfWork.BookRepository.Update(model);

                    BookDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<BookModel, BookDTO>(model);
                    }

                    return modelRTN;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Remove a Book by Id (async)
        public async Task<int> RemoveBookAsync(int BookId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.BookRepository.GetSingleOrDefaultBook(x => x.BookId == BookId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.BookRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.BookId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all Books (async)
        public async Task<List<BookDTO>> GetAllBook()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.BookRepository.GetAllBooks().ToList());
                    var temp = _Mapper_ToDTO.Map<List<BookModel>, List<BookDTO>>(models);
                    foreach (var m in temp)
                    {
                        m.BookTransactionIds = unitOfWork.BookRepository.GetAllBookTransactionsByBookId(m.BookId).ToList();
                    }
                    return temp;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Book base on "term" (async)
        public async Task<BookDTO> SearchSingleBookByNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    BookModel model = await Task.Run(() => unitOfWork.BookRepository.GetSingleOrDefaultBook(x => x.BookName.Contains(term)));
                    return _Mapper_ToDTO.Map<BookModel, BookDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single Book base on "term" (async)
        public async Task<BookDTO> SearchSingleBookByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    BookModel model = await Task.Run(() => unitOfWork.BookRepository.GetSingleOrDefaultBook(x => x.BookId == Id));
                    return _Mapper_ToDTO.Map<BookModel, BookDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is Book Exists
        public bool IsBookExistsById(int BookId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.BookRepository.Exists(x => x.BookId == BookId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search Books based on "term/string"
        public List<BookDTO> SearchBooksByBookNameAsync(string term)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    List<BookModel> models = unitOfWork.BookRepository.FindBook(x => x.BookName.Contains(term)).ToList();

                    return _Mapper_ToDTO.Map<List<BookModel>, List<BookDTO>>(models);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }
    }
}
