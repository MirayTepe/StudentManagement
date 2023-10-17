using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.DBOperations;
using WebApi.Entities;

namespace WebApi.Application.EnrolmenttOperations.Queries.GetEnrollmentDetail
{
    public class GetEnrollmentDetailQuery{
        
        public int EnrollmentId { get; set; }

        private readonly IStudentManagementDbContext _context;
        
        public GetEnrollmentDetailViewModel Model { get; set; }
    
        private readonly IMapper _mapper;


        public GetEnrollmentDetailQuery(IStudentManagementDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public GetEnrollmentDetailViewModel Handle()
        {
           
            var enrollment = _context.Enrollments.Include(x=>x.Student).Include(x=>x.Course).SingleOrDefault(s=>s.Id==EnrollmentId);
            if (enrollment is null)
                throw new InvalidOperationException("Kayıt bulunamadı!");
           

            GetEnrollmentDetailViewModel vm = _mapper.Map<GetEnrollmentDetailViewModel>(enrollment);

            return vm;
        }
    }
     
    public class GetEnrollmentDetailViewModel
    {
        public string Course{get;set;}
        public string Student{get;set;}
        public DateTime EnrollmentDate{get; set;}

     
     
    }


}