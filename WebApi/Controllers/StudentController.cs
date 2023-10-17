using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using Microsoft.AspNetCore.Authorization;
using WebApi.DBOperations;
using WebApi.Application.CourseOperations.Commands.GetCourses;
using WebApi.Application.CourseOperations.Commands.GetCourseDetail;
using WebApi.Application.CourseOperations.Commands.CreateCourse;
using WebApi.Application.CourseOperations.Commands.UpdateCourse;
using WebApi.Application.CourseOperations.Commands.DeleteCourse;
using WebApi.Application.StudentOperations.Queries.GetStudents;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.Application.StudentOperations.Commands.CreateStudent;


namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentManagementDbContext _context; 
        private readonly IMapper _mapper;
        public StudentController(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetStudents()
        {
            GetStudentsQuery query = new GetStudentsQuery(_context, _mapper);
            return Ok(query.Handle());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            GetStudentDetailQuery query = new GetStudentDetailQuery(_context, _mapper);
            query.StudentId = id;          
            GetStudentDetailQueryValidator validator = new GetStudentDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult AddStudent([FromBody] CreateStudentViewModel newStudent)
        {
            CreateStudentCommand command = new CreateStudentCommand(_context, _mapper);

            command.Model = newStudent;
            
            CreateStudentCommandValidator validator = new CreateStudentCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] UpdateStudentViewModel updatedStudent)
        {
            UpdateStudentCommand command = new UpdateStudentCommand(_context, _mapper);
            
            command.StudentId = id;
            command.Model = updatedStudent;
            
            UpdateStudentCommandValidator validator = new UpdateStudentCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            DeleteStudentCommand command = new DeleteStudentCommand(_context);
            
            command.StudentId = id;
            //VALIDATIONS
            command.Handle();
            
            return Ok();
        }
    }
}