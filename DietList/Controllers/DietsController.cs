using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Diet.Models;

namespace Diet.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DietsController : ControllerBase
  {
    private readonly DietContext _db;

    public DietsController(DietContext db)
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
  }
}