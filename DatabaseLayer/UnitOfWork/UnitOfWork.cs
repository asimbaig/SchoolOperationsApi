using DatabaseLayer.Context;
using DatabaseLayer.Repository;
using DatabaseLayer.Repository.Implementations;
using DatabaseLayer.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext dbContext;
        public IGenericRepository Repository { get; set; }
        public ISchoolRepository SchoolRepository { get; set; }
        public IExceptionLoggerRepository ExceptionLoggerRepository { get; set; }
        public IApiLogRepository ApiLogRepository { get; set; }
        public IImageFileTypeRepository ImageFileTypeRepository { get; set; }
        public IAssessmentRepository AssessmentRepository { get; set; }
        public IAttendanceRepository AttendanceRepository { get; set; }
        public IBookRepository BookRepository { get; set; }
        public IBookTransactionRepository BookTransactionRepository { get; set; }
        public IEventRepository EventRepository { get; set; }
        public IHomeworkRepository HomeworkRepository { get; set; }
        public IImageFileUrlRepository ImageFileUrlRepository { get; set; }
        public IParentRepository ParentRepository { get; set; }
        public IStandardRepository StandardRepository { get; set; }
        public IStudentRepository StudentRepository { get; set; }
        public ISubjectRepository SubjectRepository { get; set; }
        public ITeacherRepository TeacherRepository { get; set; }
        public IYearRepository YearRepository { get; set; }
        public IOperationalStaffRepository OperationalStaffRepository { get; set; }


        //IGenericRepository IUnitOfWork.Repository => throw new NotImplementedException();

        public UnitOfWork()
        {
            dbContext = new DatabaseContext();
            Repository = new GenericRepository(dbContext);
            SchoolRepository = new SchoolRepository(dbContext);
            ExceptionLoggerRepository = new ExceptionLoggerRepository(dbContext);
            ApiLogRepository = new ApiLogRepository(dbContext);
            ImageFileTypeRepository = new ImageFileTypeRepository(dbContext);
            AssessmentRepository = new AssessmentRepository(dbContext);
            AttendanceRepository = new AttendanceRepository(dbContext);
            BookRepository = new BookRepository(dbContext);
            BookTransactionRepository = new BookTransactionRepository(dbContext);
            EventRepository = new EventRepository(dbContext);
            HomeworkRepository = new HomeworkRepository(dbContext);
            ImageFileUrlRepository = new ImageFileUrlRepository(dbContext);
            ParentRepository = new ParentRepository(dbContext);
            StandardRepository = new StandardRepository(dbContext);
            StudentRepository = new StudentRepository(dbContext);
            SubjectRepository = new SubjectRepository(dbContext);
            TeacherRepository = new TeacherRepository(dbContext);
            YearRepository = new YearRepository(dbContext);
            OperationalStaffRepository = new OperationalStaffRepository(dbContext);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }
                dbContext.Dispose();
                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UnitOfWork() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
