using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QLSV_API.Models;

namespace QLSV_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly SinhVienContext _context;

        public StudentsController(SinhVienContext context)
        {
            _context = context;
        }

        // GET: api/Students
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
          if (_context.Students == null)
          {
              return NotFound();
          }
            var student = await _context.Students.Select(s => new
            {   
                s.IdStudent,
                s.NameStudent,
                s.BirthdayStudent,
                s.Gender,
                s.IdFaculty,
                s.IdFacultyNavigation.NameFaculty,
                
            }).ToListAsync();
            return Ok(student);
        }

        // GET: api/Students/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
          if (_context.Students == null)
          {
              return NotFound();
          }
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> PutStudent(int id, Student student)
        {
            if (id != student.IdStudent)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return await _context.Students.ToListAsync();
        }

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Student>>> PostStudent(Student student)
        {
          if (_context.Students == null)
          {
              return Problem("Entity set 'SinhVienContext.Students'  is null.");
          }
            _context.Students.Add(student);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.IdStudent))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            //return CreatedAtAction("GetStudent", new { id = student.IdStudent }, student);
            return await _context.Students.ToListAsync();
        }

        // DELETE: api/Students/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<IEnumerable<Student>>> DeleteStudent(int id)
        {
            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }

        [HttpDelete("DelelteAll")]
        public async Task<ActionResult<IEnumerable<Student>>> DeleteAll(List<int> ids)
        {
            if (ids == null || ids.Count == 0)
            {
                return BadRequest("No IDs provided");
            }

            foreach (var id in ids)
            {
                var student = await _context.Students.FindAsync(id);
                if (student != null)
                {
                    _context.Students.Remove(student);
                }
            }

            await _context.SaveChangesAsync();

            return await _context.Students.ToListAsync();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.IdStudent == id)).GetValueOrDefault();
        }


    }
}
