using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Operations;
using StudentManagment.Models;
using StudentManagment.Services;

namespace StudentManagment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }
        [HttpGet]
        public ActionResult<List<Student>> Get()
            {
            return studentService.Get();
        }
        [HttpGet("{id}")]
        public ActionResult<Student> Get(string id)
        {
            var student = studentService.Get(id);

            if(student == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }
            return student;
        }

        [HttpPost]
        public ActionResult<Student> Post([FromBody]Student student)
        {
         studentService.Create(student);
            return CreatedAtAction(nameof(Get), new { id = student.ID }, student);
        }
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]Student student)
        {
            var existingStudents = studentService.Get(id);

            if(existingStudents == null)
            {
                return NotFound($"Student with id = {id} not found");
            }
            studentService.Update(id, student);
           
            return NoContent();
        }
        
    }
   
   
}