using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuAnTotNghiep.Data;
using DuAnTotNghiep.Models;
using Microsoft.Identity.Client;

namespace DuAnTotNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/QuocGia")]
    public class QuocGiaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuocGiaController(ApplicationDbContext context)
        {
            _context = context;
        }


        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            return _context.QuocGia != null ?
                        View(await _context.QuocGia.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.QuocGia'  is null.");
        }

        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.QuocGia == null)
            {
                return NotFound();
            }

            var quocGia = await _context.QuocGia
                .FirstOrDefaultAsync(m => m.ID_QuocGia == id);
            if (quocGia == null)
            {
                return NotFound();
            }

            return View(quocGia);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TenNuoc")] QuocGia quocGia)
        {
            if (ModelState.IsValid)
            {
                quocGia.ID_QuocGia = Guid.NewGuid();
                _context.Add(quocGia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quocGia);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.QuocGia == null)
            {
                return NotFound();
            }

            var quocGia = await _context.QuocGia.FindAsync(id);
            if (quocGia == null)
            {
                return NotFound();
            }
            return View(quocGia);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(QuocGia quocGia)
        {
            var Edit = _context.QuocGia.FirstOrDefault(a => a.ID_QuocGia == quocGia.ID_QuocGia);
            if (ModelState.IsValid)
            {

                try
                {

                    Edit.TenNuoc = quocGia.TenNuoc;
                    _context.Update(Edit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ChatLieuExists(Edit.ID_QuocGia))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Edit);
        }
        
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.QuocGia == null)
            {
                return NotFound();
            }

            var quocGia = await _context.QuocGia
                .FirstOrDefaultAsync(m => m.ID_QuocGia == id);
            if (quocGia == null)
            {
                return NotFound();
            }

            return View(quocGia);
        }

        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.QuocGia == null)
            {
                return Problem("Entity set 'ApplicationDbContext.QuocGia'  is null.");
            }
            var quocGia = await _context.QuocGia.FindAsync(id);
            if (quocGia != null)
            {
                _context.QuocGia.Remove(quocGia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatLieuExists(Guid id)
        {
            return (_context.QuocGia?.Any(e => e.ID_QuocGia == id)).GetValueOrDefault();
        }
    }
}
