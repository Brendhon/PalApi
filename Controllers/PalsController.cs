using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PalData;
using PalModel;
using Newtonsoft.Json;

namespace PalApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PalsController : Controller
  {
    private readonly PalContext _context;

    public PalsController(PalContext context)
    {
      _context = context;
    }

    // GET: Pals
    // url: /api/pals
    [HttpGet]
    public async Task<IActionResult> Index()
    {
      // Return all pals from the database
      return Ok(await _context.Pals.ToListAsync());
    }

    // GET: Pals/Details/5
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

    // PUT: Pals/Edit/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var pal = await _context.Pals.FindAsync(id);
      if (pal == null)
      {
        return NotFound();
      }

      return Ok(pal);
    }

    // POST: Pals/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type")] Pal pal)
    {
      if (id != pal.Id)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(pal);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!PalExists(pal.Id))
          {
            return NotFound();
          }
          else
          {
            throw;
          }
        }
        return RedirectToAction(nameof(Index));
      }
      return Ok(pal);
    }

    // DELETE: Pals/Delete/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int? id)
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

    private bool PalExists(int id)
    {
      return _context.Pals.Any(e => e.Id == id);
    }
  }
}
