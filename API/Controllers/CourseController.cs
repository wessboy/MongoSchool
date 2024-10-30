using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistance.Entities;
using Persistance.Interfaces;

namespace API.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ILogger<CourseController> _logger;
        private readonly ICourseService _courseService;
        public CourseController(ILogger<CourseController> logger,ICourseService courseService)
        {
            _logger = logger;   
            _courseService = courseService; 
        }

     [HttpGet("{id:length(24)}")]
     public async Task<ActionResult<Course>> GetOne(string id)
    {
        if (string.IsNullOrEmpty(id)) return BadRequest("Invalid Id !!");

        var courseFromDb = await _courseService.GetById(id);

        return courseFromDb is null ? NotFound($"No course with id : {id} exists") : Ok(courseFromDb);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Course course)
    {
        if (course is null) return BadRequest("Invalid Data Entry !!");
        
          var newCourse = await _courseService.Create(course);

        return newCourse is null ? 
               UnprocessableEntity("Create Operation Failed")
               : CreatedAtAction(nameof(GetOne), new { id = newCourse.Id },newCourse);

    }
}

