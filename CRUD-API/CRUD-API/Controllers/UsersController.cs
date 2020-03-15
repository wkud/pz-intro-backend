using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD_Core.Contexts;
using CRUD_Core.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CRUD_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserContext _context;

        public UsersController(UserContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<UserDto>> GetUsers()
        {
            return _context.UsersDto;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public ActionResult<UserDto> GetUser(long id)
        {
            var user = _context.UsersDto.Find(dto => dto.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public IActionResult PutUser(long id, UserDto userDto)
        {
            if (id != userDto.Id)
            {
                return BadRequest();
            }

            _context.SetEntryState(userDto, EntityState.Modified);

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Contains(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Users
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public ActionResult<UserDto> PostUser(UserDto userDto)
        {
            _context.AddUser(userDto);
            _context.SaveChanges();

            return CreatedAtAction("GetUser", new { id = userDto.Id }, userDto);
        }


        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            if (_context.Contains(id))
            {
                return NotFound();
            }

            _context.RemoveUser(id);
            _context.SaveChanges();
            return Ok();
        }

    }
}
