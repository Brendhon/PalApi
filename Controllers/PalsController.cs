using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PalData;
using PalModel;

namespace PalApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PalsController(PalContext context) : Controller
  {
    private readonly PalContext _context = context;

    // GET: Pals
    // url: /api/pals
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      // Return all pals from the database
      return Ok(await _context.Pals.ToListAsync());
    }

    // GET: /api/pals/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var pal = await _context.Pals
          .FirstOrDefaultAsync(m => m.Id == id);
      if (pal == null)
      {
        return NotFound();
      }

      return Ok(pal);
    }

    // PUT: /api/pals/5 ignore id in the body
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int? id, [Bind("Name,Type")] Pal pal)
    {
      if (id == null || pal == null)
      {
        return BadRequest(new { error = "Id and pal are required" });
      }

      if (id != pal.Id)
      {
        return BadRequest(new { error = "Id mismatch" });
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      try
      {
        _context.Update(pal);
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!await PalExists(pal.Id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      // Add the return statement here
      return Ok(pal);
    }

    // POST: /api/pals
    [HttpPost]
    public async Task<IActionResult> Create([Bind("Id,Name,Type")] Pal pal)
    {
      // Validate the model
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      // Check if the pal already exists
      if (await PalExists(pal.Id))
      {
        // Return a 400 Bad Request - with json error message
        return BadRequest(new { error = "Pal already exists" });
      }

      // Add the new pal to the database
      _context.Add(pal);

      // Save the changes
      await _context.SaveChangesAsync();

      // Return the new pal
      return CreatedAtAction("Details", new { id = pal.Id }, pal);
    }

    // DELETE: /api/pals/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int? id)
    {
      // Check if the id is null
      if (id == null)
      {
        return NotFound();
      }

      // Get the pal from the database
      var pal = await _context.Pals.FirstOrDefaultAsync(m => m.Id == id);

      // Check if the pal exists
      if (pal == null)
      {
        return NotFound();
      }
      else // Delete the pal
      {
        _context.Pals.Remove(pal);
        await _context.SaveChangesAsync();
      }

      // Return the deleted pal
      return Ok(pal);
    }

    private async Task<bool> PalExists(int id)
    {
      return await _context.Pals.AnyAsync(e => e.Id == id);
    }
  }
}
