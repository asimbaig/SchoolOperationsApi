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
    public class ExceptionLoggerService : BaseService,IExceptionLoggerService
    {
        public ExceptionLoggerService() : base()
        {
            SetAutoMapper_ExceptionLogger();
        }
        public async Task<int> AddExceptionAsync(ExceptionLoggerDTO modelDTO)
        {
            try
            {
                using (var unitOfWork = unitOfWorkFactory.Create())
                {
                    ExceptionLogger model = _Mapper_ToModel.Map<ExceptionLoggerDTO, ExceptionLogger>(modelDTO);

                    unitOfWork.ExceptionLoggerRepository.Add(model);
                    await unitOfWork.SaveChangesAsync();
                    return model.Id;
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
