using Microsoft.AspNetCore.Mvc;
using Persistance.Entities;
using Persistance.Interfaces;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StudentController : ControllerBase
{

    private readonly IStudentService _studentService;
    private readonly ILogger<StudentController> _logger;    
    public StudentController(IStudentService studentService, ILogger<StudentController> logger)
    {
        _studentService = studentService;
        _logger = logger;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<Student>>> GetAll()
    {
        var students = await _studentService.GetAll();

        if (!students.Any()) return NotFound("No Record Found");

        _logger.LogInformation($"stuents : {students.Count} at {DateTime.Now}");

        return Ok(students);
    }


    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<Student>> GetOne(string id)
    {
        if (string.IsNullOrEmpty(id)) return BadRequest("Invalid Id !!");

        var studentFromDb = await _studentService.GetById(id);

         _logger.LogInformation($"Student From Db : {studentFromDb} at {DateTime.Now}");

        return studentFromDb is null ? NotFound($"No Student with id:{id}  exists") : Ok(studentFromDb);
    }

    [HttpPost]
    public async Task<ActionResult> Create(Student student)
    {
        if (student is null) return BadRequest("Invalid Data Entery !!");

        var studentFromDb = await _studentService.GetByName(student.FirstName, student.LastName);

        if (studentFromDb is not null) return BadRequest("Student already Exists !!");

        var newStudent = await _studentService.Create(student);

        _logger.LogInformation($"Created Student : {newStudent} at {DateTime.Now}");

        return CreatedAtAction(nameof(GetOne), new { id = newStudent?.Id }, newStudent);
    }

    [HttpPut]
    public async Task<ActionResult> Update(string id,Student updatedstudent)
    {
        if(string.IsNullOrEmpty(id) || updatedstudent is null) return BadRequest("Invalid Data Entry !!");

          var studentFromDb = await _studentService.GetById(id);

        if (studentFromDb is null) return NotFound($"No Student with id:{id}  exists");


        var result = await _studentService.Update(id,updatedstudent);

       string newid = (string)result.UpsertedId;
       
        return result.IsAcknowledged ?  NoContent() : UnprocessableEntity("Update Operation Failed");
    }

    [HttpDelete("{id:length(24)}")]
    public async Task<ActionResult> Delete(string id)
    {
        if (string.IsNullOrEmpty(id)) return BadRequest("Invalid Id !!");

        var studentFromDb = await _studentService.GetById(id);

        if (studentFromDb is null) return NotFound($"No Student with id:{id}  exists");

        var result = await _studentService.Delete(id);
        
        return result.IsAcknowledged ? NoContent() : UnprocessableEntity("Delete Operation Failed");


    }

       
        
    }

