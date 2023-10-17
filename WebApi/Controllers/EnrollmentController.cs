using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using Microsoft.AspNetCore.Authorization;
using WebApi.DBOperations;
using WebApi.Application.StudentOperations.Queries.GetStudents;
using WebApi.Application.StudentOperations.Queries.GetStudentDetail;
using WebApi.Application.StudentOperations.Commands.UpdateStudent;
using WebApi.Application.StudentOperations.Commands.DeleteStudent;
using WebApi.Application.StudentOperations.Commands.CreateStudent;
using WebApi.Application.CourseOperations.Commands.GetEnrollments;
using WebApi.Application.EnrolmenttOperations.Queries.GetEnrollmentDetail;
using WebApi.Application.EnrollmentOperations.Commands.CreateEnrollment;
using WebApi.Application.EnrollmentOperations.Commands.DeleteEnrollment;
using WebApi.Application.EnrollmentOperations.Commands.UpdateEnrollment;


namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IStudentManagementDbContext _context; 
        private readonly IMapper _mapper;
        public EnrollmentController(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetEnrollments()
        {
            GetEnrollmentsQuery query = new GetEnrollmentsQuery(_context, _mapper);
            return Ok(query.Handle());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetEnrollmentById(int id)
        {
            GetEnrollmentDetailQuery query = new GetEnrollmentDetailQuery(_context, _mapper);
            query.EnrollmentId = id;          
            GetEnrollmentDetailQueryValidator validator = new GetEnrollmentDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult AddEnrollment([FromBody] CreateEnrollmentViewModel newEnrollment)
        {
            CreateEnrollmentCommand command = new CreateEnrollmentCommand(_context, _mapper);

            command.Model = newEnrollment;
            
            CreateEnrollmentCommandValidator validator = new CreateEnrollmentCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateEnrollment(int id, [FromBody] UpdateEnrollmentViewModel updatedEnrollment)
        {
            UpdateEnrollmentCommand command = new UpdateEnrollmentCommand(_context, _mapper);
            
            command.EnrollmentId = id;
            command.Model = updatedEnrollment;
            
            UpdateEnrollmentCommandValidator validator = new UpdateEnrollmentCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteEnrollment(int id)
        {
            DeleteEnrollmentCommand command = new DeleteEnrollmentCommand(_context);
            
            command.EnrollmentId = id;
            //VALIDATIONS
            command.Handle();
            
            return Ok();
        }
    }
}