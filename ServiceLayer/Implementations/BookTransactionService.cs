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
    public class BookTransactionService : BaseService, IBookTransactionService
    {
        public BookTransactionService() : base()
        {
            SetAutoMapper_BookTransaction();
        }

        //Add BookTransaction (async)
        public async Task<int> AddBookTransactionAsync(BookTransactionDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    //BookModel tempBook = unitOfWork.BookRepository.GetSingleOrDefaultBook(x => x.BookId == modelDTO.BookId);

                    //modelDTO.BookId = tempBook.BookId;

                    //StudentModel tempStudent = unitOfWork.StudentRepository.GetSingleOrDefaultStudent(x => x.StudentId == modelDTO.StudentId);

                    //modelDTO.StudentId = tempStudent.StudentId;

                    BookTransactionModel model = _Mapper_ToModel.Map<BookTransactionDTO, BookTransactionModel>(modelDTO);

                    unitOfWork.BookTransactionRepository.Add(model);
                    //unitOfWork.Repository.Add<BookTransactionModel>(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.BookTransactionId;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }

        }

        //Update BookTransaction (async)
        public async Task<BookTransactionDTO> UpdateBookTransactionAsync(BookTransactionDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    BookTransactionModel model = _Mapper_ToModel.Map<BookTransactionDTO, BookTransactionModel>(modelDTO);

                    bool result = unitOfWork.BookTransactionRepository.Update(model);

                    BookTransactionDTO modelRTN = null;
                    if (result)
                    {
                        await unitOfWork.SaveChangesAsync();
                        modelRTN = _Mapper_ToDTO.Map<BookTransactionModel, BookTransactionDTO>(model);
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

        //Remove a BookTransaction by Id (async)
        public async Task<int> RemoveBookTransactionAsync(int BookTransactionId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var entity = unitOfWork.BookTransactionRepository.GetSingleOrDefaultBookTransaction(x => x.BookTransactionId == BookTransactionId);
                    if (entity == null)
                    {
                        return 0;
                    }
                    else
                    {
                        unitOfWork.BookTransactionRepository.Remove(entity);
                        await unitOfWork.SaveChangesAsync();
                        return entity.BookTransactionId;
                    }

                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Get List of all BookTransactions (async)
        public async Task<List<BookTransactionDTO>> GetAllBookTransaction()
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    var models = await Task.Run(() => unitOfWork.BookTransactionRepository.GetAllBookTransactions().ToList());
                    var temp = _Mapper_ToDTO.Map<List<BookTransactionModel>, List<BookTransactionDTO>>(models);
                    return temp;
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Find Single BookTransaction base on "term" (async)
        //public async Task<BookTransactionDTO> SearchSingleBookTransactionByNameAsync(string term)
        //{
        //    try
        //    {
        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            BookTransactionModel model = unitOfWork.BookTransactionRepository.GetSingleOrDefaultBookTransaction(x => x.BookTransactionName.Contains(term));
        //            return _Mapper_ToDTO.Map<BookTransactionModel, BookTransactionDTO>(model);
        //        }
        //    }
        //    catch (Exception ex)

        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}

        //Find Single BookTransaction base on "term" (async)

        public async Task<BookTransactionDTO> SearchSingleBookTransactionByIdAsync(int Id)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    BookTransactionModel model = await Task.Run(() => unitOfWork.BookTransactionRepository.GetSingleOrDefaultBookTransaction(x => x.BookTransactionId == Id));
                    return _Mapper_ToDTO.Map<BookTransactionModel, BookTransactionDTO>(model);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Is BookTransaction Exists
        public bool IsBookTransactionExistsById(int BookTransactionId)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    return unitOfWork.BookTransactionRepository.Exists(x => x.BookTransactionId == BookTransactionId);
                }
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw ex;
            }
        }

        //Search BookTransactions based on "term/string"
        //public List<BookTransactionDTO> SearchBookTransactionsByNameAsync(string term)
        //{
        //    try
        //    {
        //        using (var unitOfWork = unitOfWorkFactory.Create())
        //        {
        //            List<BookTransactionModel> models = unitOfWork.BookTransactionRepository.FindBookTransaction(x => x.BookTransactionName.Contains(term)).ToList();

        //            return _Mapper_ToDTO.Map<List<BookTransactionModel>, List<BookTransactionDTO>>(models);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogException(ex);
        //        throw ex;
        //    }
        //}
    }
}
