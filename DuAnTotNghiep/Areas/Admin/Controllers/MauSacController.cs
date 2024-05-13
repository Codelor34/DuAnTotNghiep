using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuAnTotNghiep.Data;
using DuAnTotNghiep.Models;

namespace DuAnTotNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/MauSac")]
    public class MauSacController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MauSacController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
              return _context.MauSac != null ? 
                          View(await _context.MauSac.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.MauSac'  is null.");
        }

        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.MauSac == null)
            {
                return NotFound();
            }

            var mauSac = await _context.MauSac
                .FirstOrDefaultAsync(m => m.ID_MauSac == id);
            if (mauSac == null)
            {
                return NotFound();
            }

            return View(mauSac);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_MauSac,Mausac")] MauSac mauSac)
        {
            if (!ModelState.IsValid)
            {
                mauSac.ID_MauSac = Guid.NewGuid();
                _context.Add(mauSac);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mauSac);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.MauSac == null)
            {
                return NotFound();
            }

            var mauSac = await _context.MauSac.FindAsync(id);
            if (mauSac == null)
            {
                return NotFound();
            }
            return View(mauSac);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID_MauSac,Mausac")] MauSac mauSac)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(mauSac);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MauSacExists(mauSac.ID_MauSac))
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
            return View(mauSac);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.MauSac == null)
            {
                return NotFound();
            }

            var mauSac = await _context.MauSac
                .FirstOrDefaultAsync(m => m.ID_MauSac == id);
            if (mauSac == null)
            {
                return NotFound();
            }

            return View(mauSac);
        }

        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.MauSac == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MauSac'  is null.");
            }
            var mauSac = await _context.MauSac.FindAsync(id);
            if (mauSac != null)
            {
                _context.MauSac.Remove(mauSac);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MauSacExists(Guid id)
        {
          return (_context.MauSac?.Any(e => e.ID_MauSac == id)).GetValueOrDefault();
        }
    }
}
