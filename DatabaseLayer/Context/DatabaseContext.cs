using DatabaseLayer.Models;
using DatabaseLayer.Models.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Context
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext() : base("name=DefaultConnection") {
            //Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, DatabaseLayer.Migrations.Configuration>());
        }

        public DbSet<AssessmentModel> Assessments { get; set; }
        public DbSet<AttendanceModel> Attendances { get; set; }
        public DbSet<BookModel> Books { get; set; }
        public DbSet<BookTransactionModel> BookTransactions { get; set; }
        public DbSet<StandardModel> Standards { get; set; }
        public DbSet<EventModel> Events { get; set; }
        public DbSet<HomeworkModel> Homeworks { get; set; }
        public DbSet<ParentModel> Parents { get; set; }
        public DbSet<SchoolModel> Schools { get; set; }
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<SubjectModel> Subjects { get; set; }
        public DbSet<TeacherModel> Teachers { get; set; }
        public DbSet<YearModel> Years { get; set; }
        public DbSet<ImageFileUrlModel> ImageFileUrls { get; set; }
        public DbSet<ImageFileTypeModel> ImageFileTypes { get; set; }
        public DbSet<ExceptionLogger> ExceptionLoggers { get; set; }
        public DbSet<ApiLog> ApiLogs { get; set; }
        public DbSet<OperationalStaffModel> OperationalStaffs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new AssessmentMap());
            modelBuilder.Configurations.Add(new AttendanceMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new BookTransactionMap());
            modelBuilder.Configurations.Add(new EventMap());
            modelBuilder.Configurations.Add(new HomeworkMap());
            modelBuilder.Configurations.Add(new ImageFileTypeMap());
            modelBuilder.Configurations.Add(new ImageFileUrlMap());
            modelBuilder.Configurations.Add(new ParentMap());
            modelBuilder.Configurations.Add(new SchoolMap());
            modelBuilder.Configurations.Add(new StandardMap());
            modelBuilder.Configurations.Add(new StudentMap());
            modelBuilder.Configurations.Add(new SubjectMap());
            modelBuilder.Configurations.Add(new TeacherMap());
            modelBuilder.Configurations.Add(new YearMap());
            modelBuilder.Configurations.Add(new ExceptionLoggerMap());
            modelBuilder.Configurations.Add(new ApiLogMap());
            modelBuilder.Configurations.Add(new OperationalStaffMap());
        }
        //public Task<int> SaveChangesAync(CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<int> SaveChangesAync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
