using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DietList.Models;
using System.Linq;

namespace DietList.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DietsController : ControllerBase
  {
    private readonly DietListContext _db;

    public DietsController(DietListContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Diet>>> Get(string name)
    {
      var query = _db.Diets.AsQueryable();
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Diet>> GetDiet(int id)
    {
      var diet = await _db.Diets.FindAsync(id);

      if (diet == null)
      {
        return NotFound();
      }

      return diet;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Diet diet)
    {
      if (id != diet.DietId)
      {
        return BadRequest();
      }

      _db.Entry(diet).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DietExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<Diet>> Post(Diet diet)
    {
      _db.Diets.Add(diet);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetDiet), new { id = diet.DietId }, diet);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDiet(int id)
    {
      var diet = await _db.Diets.FindAsync(id);
      if (diet == null)
      {
        return NotFound();
      }

      _db.Diets.Remove(diet);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool DietExists(int id)
    {
      return _db.Diets.Any(e => e.DietId == id);
    }
  }
}
