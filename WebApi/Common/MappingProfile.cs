using AutoMapper;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.GetCourseDetail;
using WebApi.Application.CourseOperations.Commands.GetCourses;
using WebApi.Application.CourseOperations.Commands.GetEnrollments;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.EnrollmentOperations.Commands.UpdateEnrollment;
using WebApi.Application.EnrolmenttOperations.Queries.GetEnrollmentDetail;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.Application.StudentOperations.Queries.GetStudents;
using WebApi.Application.TeacherOperations.Commands.CreateTeacher;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using WebApi.Application.TeacherOperations.Queries.GetTeacherDetail;
using WebApi.Application.TeacherOperations.Queries.GetTeachers;
using WebApi.Entities;
using static WebApi.Application.UserOperations.Commands.CreateUser.CreateUserCommand;

namespace WebApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        { 
            CreateMap<CreateCourseViewModel, Course>().ReverseMap();
			CreateMap<UpdateCourseViewModel, Course>().ReverseMap();
			CreateMap<Course, GetCourseDetailViewModel>() 
            .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src =>"Id:"+src.Teacher.Id+", Ad-Soyad:" +src.Teacher.FirstName+" "+src.Teacher.LastName+", TC Kimlik No:"+src.Teacher.IdentityNumber));
      

            CreateMap<Course, GetCoursesViewModel>()
            .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src =>"Id:"+src.Teacher.Id+", Ad-Soyad:" +src.Teacher.FirstName+" "+src.Teacher.LastName+", TC Kimlik No:"+src.Teacher.IdentityNumber));
            // CreateMap<GetCoursesViewModel, Course>()
            //     .ForMember(dest => dest.Teacher, opt => opt.Ignore());

            CreateMap<CreateStudentViewModel, Student>().ReverseMap();
			CreateMap<UpdateStudentViewModel, Student>().ReverseMap();
            CreateMap<Student, GetStudentDetailViewModel>() .ReverseMap();
			CreateMap<Student, GetStudentsViewModel>().ReverseMap();

            CreateMap<CreateTeacherViewModel, Teacher>().ReverseMap();
			CreateMap<UpdateTeacherViewModel, Teacher>().ReverseMap();
            CreateMap<Teacher, GetTeacherDetailViewModel>() .ReverseMap();
			CreateMap<Teacher, GetTeachersViewModel>().ReverseMap();

            CreateMap<CreateEnrollmentViewModel, Enrollment>().ReverseMap();
			CreateMap<UpdateEnrollmentViewModel, Enrollment>().ReverseMap();
            CreateMap<Enrollment, GetEnrollmentDetailViewModel>()
             .ForMember(dest => dest.Student, opt => opt.MapFrom(src =>" Öğrenci Id:"+src.Student.Id +", Öğrenci Adı:" +src.Student.FirstName+" "+src.Student.LastName))
             .ForMember(dest => dest.Course, opt => opt.MapFrom(src =>"Ders Id:"+src.Course.Id+", Ders Adı:" +src.Course.CourseName+", Ders Kodu:"+src.Course.CourseCode));
			CreateMap<Enrollment, GetEnrolmentsViewModel>()
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src =>" Öğrenci Id:"+src.Student.Id +", Öğrenci Adı:" +src.Student.FirstName+" "+src.Student.LastName))
             .ForMember(dest => dest.Course, opt => opt.MapFrom(src =>"Ders Id:"+src.Course.Id+", Ders Adı:" +src.Course.CourseName+", Ders Kodu:"+src.Course.CourseCode));
               
            CreateMap<CreateUserModel,User>().ReverseMap();

        }
    }
}