using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Data.ProWriter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
 
namespace Api.ProWriter.Controllers
{
    [ApiController, Route("api/[controller]"), AllowAnonymous]
    public class BaseController<Db, Ent> : Controller 
           where Db : DbContext
          where Ent : class, IEntity
    {
        protected readonly Db _context;
        protected readonly DbSet<Ent> _dbSet;

        public BaseController(Db context, DbSet<Ent> dbSet)
        {
            _context = context;
            _dbSet = dbSet;
        }

        [HttpGet("")]
        virtual public IActionResult Get()
        {
            var data = _dbSet.AsNoTracking();
            return Ok(data);
        }

        [HttpGet("{id}")]
        virtual public async Task<IActionResult> Get(int id)
        {
            var dbEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (dbEntity == null) return NotFound();
             
            return Ok(dbEntity);
        }

        [HttpPut("{id}")]
        virtual public async Task<IActionResult> Put(int id, [FromBody] Ent dbEntity)
        {
            if (id != dbEntity.Id) return BadRequest();

            _context.Entry(dbEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (Exists(id) == false) return NotFound();

                throw;
            }

            return NoContent();
        }

        [HttpPost]
        virtual public async Task<ActionResult<Ent>> Post([FromBody] Ent dbEntity)
        {
            _dbSet.Add(dbEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = dbEntity.Id }, dbEntity);
        }

        [HttpDelete("{id}")]
        virtual public async Task<ActionResult<Ent>> Delete(int id)
        {
            var dbEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (dbEntity == null) return NotFound();

            _dbSet.Remove(dbEntity);
            await _context.SaveChangesAsync();

            return dbEntity;
        }

        private bool Exists(int id)
        {
            return _dbSet.Any(e => e.Id == id);
        }

        protected int UserId
        {
            get
            {
                int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int val);

                return val;
            }
        }
    }
}
