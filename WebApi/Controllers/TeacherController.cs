using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

using Microsoft.AspNetCore.Authorization;
using WebApi.DBOperations;
using WebApi.Application.TeacherOperations.Queries.GetTeachers;
using WebApi.Application.TeacherOperations.Queries.GetTeacherDetail;
using WebApi.Application.TeacherOperations.Commands.UpdateTeacher;
using WebApi.Application.TeacherOperations.Commands.DeleteTeacher;
using WebApi.Application.TeacherOperations.Commands.CreateTeacher;


namespace WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]s")]
    public class TeacherController : ControllerBase
    {
        private readonly IStudentManagementDbContext _context; 
        private readonly IMapper _mapper;
        public TeacherController(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpGet]
        public IActionResult GetTeachers()
        {
            GetTeachersQuery query = new GetTeachersQuery(_context, _mapper);
            return Ok(query.Handle());
        }
        
        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            GetTeacherDetailQuery query = new GetTeacherDetailQuery(_context, _mapper);
            query.TeacherId = id;          
            GetTeacherDetailQueryValidator validator = new GetTeacherDetailQueryValidator();
            validator.ValidateAndThrow(query);
            var result=query.Handle();
            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult AddTeacher([FromBody] CreateTeacherViewModel newTeacher)
        {
             
            CreateTeacherCommand command = new CreateTeacherCommand(_context, _mapper);

            command.Model = newTeacher;
            
            CreateTeacherCommandValidator validator = new CreateTeacherCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok();
        }
        
        [HttpPut("{id}")]
        public IActionResult UpdateTeacher(int id, [FromBody] UpdateTeacherViewModel updatedTeacher)
        {
            UpdateTeacherCommand command = new UpdateTeacherCommand(_context, _mapper);
            
            command.TeacherId = id;
            command.Model = updatedTeacher;
            
            UpdateTeacherCommandValidator validator = new UpdateTeacherCommandValidator();
            validator.ValidateAndThrow(command);
            
            command.Handle();
            
            return Ok();
        }
        
        [HttpDelete("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            DeleteTeacherCommand command = new DeleteTeacherCommand(_context);
            
            command.TeacherId = id;
            //VALIDATIONS
            command.Handle();
            
            return Ok();
        }
    }
}