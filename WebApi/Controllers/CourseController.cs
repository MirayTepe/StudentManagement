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


namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class CourseController : ControllerBase
    {
        private readonly IStudentManagementDbContext _context; 
        private readonly IMapper _mapper;
        public CourseController(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetCourses()
        {
            GetCoursesQuery query = new GetCoursesQuery(_context, _mapper);
            return Ok(query.Handle());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetCourseById(int id)
        {
            GetCourseDetailQuery query = new GetCourseDetailQuery(_context, _mapper);
            query.CourseId = id;          
            GetCourseDetailQueryValidator validator = new GetCourseDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult AddCourse([FromBody] CreateCourseViewModel newCourse)
        {
            CreateCourseCommand command = new CreateCourseCommand(_context, _mapper);

            command.Model = newCourse;
            
            CreateCourseCommandValidator validator = new CreateCourseCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateCourse(int id, [FromBody] UpdateCourseViewModel updatedCourse)
        {
            UpdateCourseCommand command = new UpdateCourseCommand(_context, _mapper);
            
            command.CourseId = id;
            command.Model = updatedCourse;
            
            UpdateCourseCommandValidator validator = new UpdateCourseCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteCourse(int id)
        {
            DeleteCourseCommand command = new DeleteCourseCommand(_context);
            
            command.CourseId = id;
            //VALIDATIONS
            command.Handle();
            
            return Ok();
        }
    }
}