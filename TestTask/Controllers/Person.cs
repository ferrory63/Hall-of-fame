using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestTask.Context;
using TestTask.Models;


namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly Context.PersonContext _context;
        
        public PersonController(Context.PersonContext context)
        {
            _context = context;
        }

        /// <summary>
        /// GET api/person/persons
        /// </summary>
        /// <returns>List of all persons</returns>

        [HttpGet("persons")]
        public async Task<List<Person>> PersonsAsync()
        {
            var persons = await _context.Persons
                .Include(p => p.Skills)
                .AsNoTracking()
                .ToListAsync();
            return persons;
        }
        
        /// <summary>
        /// GET api/person/{id}
        /// </summary>
        /// <param name="id">Person unique identificator</param>
        /// <returns>Person with Id</returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> PersonByIdAsync(int id)
        {
            var person = await _context.Persons.FirstOrDefaultAsync(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }
        
        /// <summary>
        /// post api/person/""
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPost("")]
        public async Task<ActionResult<Person>> AddPersonAsync(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }

            _context.Persons.Add(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
        
        /// <summary>
        /// put api/person/
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult<Person>> Put(Person person)
        {
            if (person == null)
            {
                return BadRequest();
            }
            if (!_context.Persons.Any(p => p.Id == person.Id))
            {
                return NotFound();
            }

            _context.Update(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
        
        /// <summary>
        /// delete api/person/{id}
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult<Person>> Delete(int id)
        {
            var person = _context.Persons.FirstOrDefault(x => x.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return Ok(person);
        }
        
    }
}
