using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GillesQuirynenSys.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GillesQuirynenSys.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {

        private readonly Data.MySqlDbContext _context;

        public TeacherController(Data.MySqlDbContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }
        [HttpGet]
        public IEnumerable<Teacher> GetProduct()
        {
            return _context.Teachers;
        }

        [HttpPost]
        public async Task<IActionResult> PostTeacher([FromBody] Teacher teacher)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Teachers.Add(teacher);
                await _context.SaveChangesAsync();

                return Ok(teacher);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}