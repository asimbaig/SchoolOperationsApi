using DatabaseLayer.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseLayer.Context
{
    public class DatabaseSeeder : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            //Add dummy Exception Logger
            var exceptionLoggers = new List<ExceptionLogger>
            {
                new ExceptionLogger
                {
                    ExceptionMessage = "Exception Message.",
                    SourceName = "Source of Exception",
                    ExceptionStackTrace = "StackTrace",
                    LogTime = DateTime.Now
                }
            };
            context.ExceptionLoggers.AddRange(exceptionLoggers);
            context.SaveChanges();

            //Add dummy Exception Logger
            var apiLogs = new List<ApiLog>
            {
                new ApiLog
                {
                    Host = "Host",
                    Headers = "Headers",
                    StatusCode = "Status",
                    TimeUtc = DateTime.Now,
                    RequestBody = "Body",
                    RequestedMethod = "Method",
                    UserHostAddress = "Address",
                    Useragent = "Agent",
                    AbsoluteUri = "Uri",
                    RequestType = "Type"
                }
            };
            context.ApiLogs.AddRange(apiLogs);
            context.SaveChanges();

            //Add Dummy Image/File Type
            var imageFileTypes = new List<ImageFileTypeModel>
            {
                new ImageFileTypeModel{Type="SchoolImage",IsDeleted=false},
                new ImageFileTypeModel{Type="StudentImage",IsDeleted=false},
                new ImageFileTypeModel{Type="ParentImage",IsDeleted=false},
                new ImageFileTypeModel{Type="TeacherImage",IsDeleted=false},
                new ImageFileTypeModel{Type="BookImage",IsDeleted=false},
                new ImageFileTypeModel{Type="EventImage",IsDeleted=false},
                new ImageFileTypeModel{Type="AssessmentFile",IsDeleted=false},
                new ImageFileTypeModel{Type="HomeworkFile",IsDeleted=false},
                new ImageFileTypeModel{Type="AttendanceImage",IsDeleted=false},
                new ImageFileTypeModel{Type="OperationalStaffImage",IsDeleted=false},
                new ImageFileTypeModel{Type="NoImage",IsDeleted=false}
            };
            context.ImageFileTypes.AddRange(imageFileTypes);
            context.SaveChanges();

            var images = new List<ImageFileUrlModel>
            {
                new ImageFileUrlModel()
                {
                    Url = "No Image",
                    CreateDate = DateTime.Now,
                    IsDeleted=false,
                    ImageFileType = context.ImageFileTypes.Where(x => x.Type == "NoImage").FirstOrDefault(),
                }
            };
            context.ImageFileUrls.AddRange(images);
            context.SaveChanges();

            //Add Dummy Schools
            var schools = new List<SchoolModel>
            {
                new SchoolModel{
                    SchoolName ="My School 1",
                    SchoolAddress1 ="School street",
                    SchoolAddress2 ="School Town ",
                    SchoolPostCode ="SC029YU",
                    SchoolTelephone ="0213123112",
                    SchoolWebsite ="www.myschool1.com",
                    IsDeleted=false,
                    ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MyShool1.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="SchoolImage").FirstOrDefault()
                                    }
                }
            };
            context.Schools.AddRange(schools);
            context.SaveChanges();

            //Add dummy Years
            var years = new List<YearModel>
            {
                new YearModel{year="2019",IsDeleted=false},
                new YearModel{year="2020",IsDeleted=false}
            };
            context.Years.AddRange(years);
            context.SaveChanges();

            //Add dummy Subjects
            var subjects = new List<SubjectModel>
            {
                new SubjectModel{SubjectName="English",IsDeleted=false},
                new SubjectModel{SubjectName="Maths",IsDeleted=false},
                new SubjectModel{SubjectName="History",IsDeleted=false}
            };
            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            //Add dummy Books
            var books = new List<BookModel>
            {
                new BookModel{BookName="English Book 1",
                              ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/EnglishBook1.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="BookImage").FirstOrDefault()
                              },
                              Subject = context.Subjects.Where(x=>x.SubjectName=="English").FirstOrDefault(),
                              SubjectId = context.Subjects.Where(x=>x.SubjectName=="English").FirstOrDefault().SubjectId
                },
                new BookModel{BookName="Maths Book 1",
                              ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MathsBook1.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="BookImage").FirstOrDefault()
                              },
                              Subject = context.Subjects.Where(x=>x.SubjectName=="Maths").FirstOrDefault(),
                              SubjectId = context.Subjects.Where(x=>x.SubjectName=="Maths").FirstOrDefault().SubjectId
                },
                new BookModel{BookName="History Book 1",
                              ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/HistoryBook1.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="BookImage").FirstOrDefault()
                              },
                              Subject = context.Subjects.Where(x=>x.SubjectName=="History").FirstOrDefault(),
                              SubjectId = context.Subjects.Where(x=>x.SubjectName=="History").FirstOrDefault().SubjectId
                }
            };
            context.Books.AddRange(books);
            context.SaveChanges();

            //Add dummy teachers
            var teachers = new List<TeacherModel>
            {
                new TeacherModel{TeacherName="My Teacher 1",Tr_Address1="Teacher1 street", Tr_Address2="Teacher1 Town",Tr_PostCode="TR10TY",Tr_Email="myTeacher1@school.com",Tr_Telephone="032423432",
                                 ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MyTeacher1.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="TeacherImage").FirstOrDefault()
                                 },
                                 Subjects = context.Subjects.Where(x=>x.SubjectName=="English" || x.SubjectName=="Maths").ToList()
                },
                new TeacherModel{TeacherName="My Teacher 2",Tr_Address1="Teacher2 street", Tr_Address2="Teacher2 Town",Tr_PostCode="TR02TY",Tr_Email="myTeacher2@school.com",Tr_Telephone="032432423",
                                 ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MyTeacher2.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="TeacherImage").FirstOrDefault()
                                 },
                                 Subjects = context.Subjects.Where(x=>x.SubjectName=="History" || x.SubjectName=="Maths").ToList()
                }
            };
            context.Teachers.AddRange(teachers);
            context.SaveChanges();

            //Add dummy Standards
            var standards = new List<StandardModel>
            {
                new StandardModel{StandardName="My Standard 1",
                                  IsDeleted=false,
                                  School = context.Schools.Where(x=>x.SchoolName=="My School 1").FirstOrDefault(),
                                  SchoolId = context.Schools.Where(x=>x.SchoolName=="My School 1").FirstOrDefault().SchoolId,
                                  Year = context.Years.Where(x=>x.year=="2020").FirstOrDefault(),
                                  YearId = context.Years.Where(x=>x.year=="2020").FirstOrDefault().YearId,
                                  Subjects = context.Subjects.Where(x=>x.SubjectName=="History" || x.SubjectName=="Maths").ToList(),
                                  Teachers = context.Teachers.Where(x=>x.TeacherName=="My Teacher 1" || x.TeacherName=="My Teacher 2").ToList()
                },
                new StandardModel{StandardName="My Standard 2",
                                  IsDeleted=false,
                                  School = context.Schools.Where(x=>x.SchoolName=="My School 1").FirstOrDefault(),
                                  SchoolId = context.Schools.Where(x=>x.SchoolName=="My School 1").FirstOrDefault().SchoolId,
                                  Year = context.Years.Where(x=>x.year=="2020").FirstOrDefault(),
                                  YearId = context.Years.Where(x=>x.year=="2020").FirstOrDefault().YearId,
                                  Subjects = context.Subjects.Where(x=>x.SubjectName=="English" || x.SubjectName=="Maths").ToList(),
                                  Teachers = context.Teachers.Where(x=>x.TeacherName=="My Teacher 1" || x.TeacherName=="My Teacher 2").ToList()
                }
            };
            context.Standards.AddRange(standards);
            context.SaveChanges();

            //Add dummy Parents
            var parents = new List<ParentModel>
            {
                new ParentModel{ParentName="My Parent 1",RelationType="Father", ParentAddress1="Parent1 street",ParentAddress2="Parent1 Town",ParentPostCode="PT01PSY",ParentTelephone="0324234431",ParentEmail="myparent1@school.com",
                                IsDeleted=false,
                                ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MyParent1.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="ParentImage").FirstOrDefault()
                                    }
                },
                new ParentModel{ParentName="My Parent 2",RelationType="Mother", ParentAddress1="Parent2 street",ParentAddress2="Parent2 Town",ParentPostCode="PT02PSY",ParentTelephone="0324234439",ParentEmail="myparent2@school.com",
                                IsDeleted=false,
                                ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MyParent2.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="ParentImage").FirstOrDefault()
                                }
                }
            };
            context.Parents.AddRange(parents);
            context.SaveChanges();


            //Add dummy Students
            var students = new List<StudentModel>
            {
                new StudentModel{St_Name="My Student 1",EnrolmentDate=DateTime.Now, St_Address1="Student1 street",St_Address2="Student1 Town",St_PostCode="ST01SY",St_Telephone="0324234432",St_Email="mystudent1@school.com",
                                IsDeleted=false,
                                ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MyStudent1.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="StudentImage").FirstOrDefault()
                                  },
                                 Parents = context.Parents.Where(x=>x.ParentName=="My Parent 1" || x.ParentName=="My Parent 2").ToList(),
                                 Standard = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault()
                },
                new StudentModel{St_Name="My Student 2",EnrolmentDate=DateTime.Now, St_Address1="Student2 street",St_Address2="Student2 Town",St_PostCode="ST02SY",St_Telephone="0324234433",St_Email="mystudent2@school.com",
                                IsDeleted=false,
                                ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MyStudent2.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="StudentImage").FirstOrDefault()
                                 },
                                 Parents = context.Parents.Where(x=>x.ParentName=="My Parent 1").ToList(),
                                 Standard = context.Standards.Where(x=>x.StandardName=="My Standard 2").FirstOrDefault()
                },
                new StudentModel{St_Name="My Student 3",EnrolmentDate=DateTime.Now, St_Address1="Student3 street",St_Address2="Student3 Town",St_PostCode="ST03SY",St_Telephone="0324234434",St_Email="mystudent3@school.com",
                                 ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/Image/MyStudent3.jpg",
                                        CreateDate =DateTime.Now,
                                        IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="StudentImage").FirstOrDefault()
                                 },
                                 Parents = context.Parents.Where(x=>x.ParentName=="My Parent 2").ToList(),
                                 Standard = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault()
                }
            };
            //students.ForEach(st => context.Students.Add(st));
            context.Students.AddRange(students);
            context.SaveChanges();

            //Add dummy Assessments
            var assessments = new List<AssessmentModel>
            {
                new AssessmentModel{AssessmentName="Assessment 1",AssessmentDate=DateTime.Now,IsDeleted=false,
                                    ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/File/Assessment1.doc",
                                        CreateDate =DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="AssessmentFile").FirstOrDefault()
                                    },
                                    Standard = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault(),
                                    StandardId = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault().StandardId
                },
                new AssessmentModel{AssessmentName="Assessment 2",AssessmentDate=DateTime.Now,IsDeleted=false,
                                    ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/File/Assessment2.doc",
                                        CreateDate =DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="AssessmentFile").FirstOrDefault()
                                    },
                                    Standard = context.Standards.Where(x=>x.StandardName=="My Standard 2").FirstOrDefault(),
                                    StandardId = context.Standards.Where(x=>x.StandardName=="My Standard 2").FirstOrDefault().StandardId
                },
                new AssessmentModel{AssessmentName="Assessment 3",AssessmentDate=DateTime.Now,IsDeleted=false,
                                    ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/File/Assessment3.doc",
                                        CreateDate =DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="AssessmentFile").FirstOrDefault()
                                    },
                                    Standard = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault(),
                                    StandardId = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault().StandardId
                }
            };
            context.Assessments.AddRange(assessments);
            context.SaveChanges();

            //Add dummy attendances
            var attendances = new List<AttendanceModel>
            {
                new AttendanceModel{
                                    AttendanceDate =DateTime.Now,IsDeleted=false,
                                    Present = true,
                                    Student = context.Students.Where(x=>x.St_Name=="My Student 1").FirstOrDefault(),
                                    StudentId = context.Students.Where(x=>x.St_Name=="My Student 1").FirstOrDefault().StudentId,
                                    ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/image/St1_SickNote1.jpg",
                                        CreateDate = DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="AttendanceImage").FirstOrDefault()
                                    }
                },
                new AttendanceModel{
                                    AttendanceDate =DateTime.Now,IsDeleted=false,
                                    Present = true,
                                    Student = context.Students.Where(x=>x.St_Name=="My Student 2").FirstOrDefault(),
                                    StudentId = context.Students.Where(x=>x.St_Name=="My Student 2").FirstOrDefault().StudentId,
                                    ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/image/St2_NoSickNote1.jpg",
                                        CreateDate = DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="AttendanceImage").FirstOrDefault()
                                    }
                },
                new AttendanceModel{
                                    AttendanceDate =DateTime.Now,IsDeleted=false,
                                    Present = false,
                                    Student = context.Students.Where(x=>x.St_Name=="My Student 3").FirstOrDefault(),
                                    StudentId = context.Students.Where(x=>x.St_Name=="My Student 3").FirstOrDefault().StudentId,
                                    ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/image/St3_SickNote1.jpg",
                                        CreateDate = DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="AttendanceImage").FirstOrDefault()
                                    }
                }
            };
            context.Attendances.AddRange(attendances);
            context.SaveChanges();

            //Add dummy Homeworks
            var homeworks = new List<HomeworkModel>
            {
                new HomeworkModel{HomeworkName="Homework 1",IssueDate=DateTime.Now,DueDate=null,IsDeleted=false,
                                  Standard = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault(),
                                  StandardId = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault().StandardId,
                                  ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/File/Homework1.doc",
                                        CreateDate = DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="HomeworkFile").FirstOrDefault()
                                  }
                },
                new HomeworkModel{HomeworkName="Homework 2",IssueDate=DateTime.Now,DueDate=null,IsDeleted=false,
                                  Standard = context.Standards.Where(x=>x.StandardName=="My Standard 2").FirstOrDefault(),
                                  StandardId = context.Standards.Where(x=>x.StandardName=="My Standard 2").FirstOrDefault().StandardId,
                                  ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/File/Homework2.doc",
                                        CreateDate = DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="HomeworkFile").FirstOrDefault()
                                  }
                },
                new HomeworkModel{HomeworkName="Homework 3",IssueDate=DateTime.Now,DueDate=null,IsDeleted=false,
                                  Standard = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault(),
                                  StandardId = context.Standards.Where(x=>x.StandardName=="My Standard 1").FirstOrDefault().StandardId,
                                  ImageFileUrl = new ImageFileUrlModel(){
                                        Url ="/File/Homework3.doc",
                                        CreateDate = DateTime.Now,IsDeleted=false,
                                        ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="HomeworkFile").FirstOrDefault()
                                  }
                }
            };
            context.Homeworks.AddRange(homeworks);
            context.SaveChanges();

            ////Add dummy Events
            //var events = new List<EventModel>
            //{
            //    new EventModel{EventName="Event 1",EventDate=DateTime.Now,Location="SC029YU",IsDeleted=false,
            //                   ImageFileUrls = new List<ImageFileUrlModel>
            //                   {
            //                      new ImageFileUrlModel(){
            //                            Url ="/Image/Event1_Image1.Jpg",
            //                            CreateDate = DateTime.Now,IsDeleted=false,
            //                            ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="EventImage").FirstOrDefault()
            //                      },
            //                      new ImageFileUrlModel(){
            //                            Url ="/Image/Event1_Image2.Jpg",
            //                            CreateDate = DateTime.Now,IsDeleted=false,
            //                            ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="EventImage").FirstOrDefault()
            //                      }
            //                   },
            //                   Students = context.Students.Where(x=>x.St_Name=="My Student 1" || x.St_Name=="My Student 2").ToList()
            //    },
            //    new EventModel{EventName="Event 2",EventDate=DateTime.Now,Location="SC029YU",IsDeleted=false,
            //                   ImageFileUrls = new List<ImageFileUrlModel>
            //                   {
            //                      new ImageFileUrlModel(){
            //                            Url ="/Image/Event2_Image1.Jpg",
            //                            CreateDate = DateTime.Now,IsDeleted=false,
            //                            ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="EventImage").FirstOrDefault()
            //                      },
            //                      new ImageFileUrlModel(){
            //                            Url ="/Image/Event2_Image2.Jpg",
            //                            CreateDate = DateTime.Now,IsDeleted=false,
            //                            ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="EventImage").FirstOrDefault()
            //                      }
            //                   },
            //                   Students = context.Students.Where(x=>x.St_Name=="My Student 1" || x.St_Name=="My Student 3").ToList()
            //    },
            //    new EventModel{EventName="Event 3",EventDate=DateTime.Now,Location="SC029YU",IsDeleted=false,
            //                   ImageFileUrls = new List<ImageFileUrlModel>
            //                   {
            //                      new ImageFileUrlModel(){
            //                            Url ="/Image/Event3_Image1.Jpg",
            //                            CreateDate = DateTime.Now,IsDeleted=false,
            //                            ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="EventImage").FirstOrDefault()
            //                      },
            //                      new ImageFileUrlModel(){
            //                            Url ="/Image/Event3_Image2.Jpg",
            //                            CreateDate = DateTime.Now,IsDeleted=false,
            //                            ImageFileType = context.ImageFileTypes.Where(x=>x.Type=="EventImage").FirstOrDefault()
            //                      }
            //                   },
            //                   Students = context.Students.Where(x=>x.St_Name=="My Student 3" || x.St_Name=="My Student 2").ToList()
            //    }
            //};
            //context.Events.AddRange(events);
            //context.SaveChanges();

            //Add dummy Book Transaction
            var bookTransactions = new List<BookTransactionModel>
            {
                new BookTransactionModel{IssueDate=DateTime.Now,ReturnDate=null,IsDeleted=false,
                                         Book = context.Books.Where(x=>x.BookName=="English Book 1").FirstOrDefault(),
                                         BookId = context.Books.Where(x=>x.BookName=="English Book 1").FirstOrDefault().BookId,
                                         Student = context.Students.Where(x=>x.St_Name=="My Student 1").FirstOrDefault(),
                                         StudentId = context.Students.Where(x=>x.St_Name=="My Student 1").FirstOrDefault().StudentId
                },
                new BookTransactionModel{IssueDate=DateTime.Now,ReturnDate=null,IsDeleted=false,
                                         Book = context.Books.Where(x=>x.BookName=="Maths Book 1").FirstOrDefault(),
                                         BookId = context.Books.Where(x=>x.BookName=="English Book 1").FirstOrDefault().BookId,
                                         Student = context.Students.Where(x=>x.St_Name=="My Student 2").FirstOrDefault(),
                                         StudentId = context.Students.Where(x=>x.St_Name=="My Student 2").FirstOrDefault().StudentId
                },
                new BookTransactionModel{IssueDate=DateTime.Now,ReturnDate=null,IsDeleted=false,
                                         Book = context.Books.Where(x=>x.BookName=="History Book 1").FirstOrDefault(),
                                         BookId = context.Books.Where(x=>x.BookName=="English Book 1").FirstOrDefault().BookId,
                                         Student = context.Students.Where(x=>x.St_Name=="My Student 3").FirstOrDefault(),
                                         StudentId = context.Students.Where(x=>x.St_Name=="My Student 3").FirstOrDefault().StudentId
                }
            };
            context.BookTransactions.AddRange(bookTransactions);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
