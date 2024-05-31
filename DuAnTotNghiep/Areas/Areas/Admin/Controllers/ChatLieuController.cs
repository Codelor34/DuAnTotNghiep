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
    [Route("Admin/ChatLieu")]
    public class ChatLieuController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ChatLieuController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
              return _context.ChatLieu != null ? 
                          View(await _context.ChatLieu.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.ChatLieu'  is null.");
        }

        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.ChatLieu == null)
            {
                return NotFound();
            }

            var chatLieu = await _context.ChatLieu
                .FirstOrDefaultAsync(m => m.ID_ChatLieu == id);
            if (chatLieu == null)
            {
                return NotFound();
            }

            return View(chatLieu);
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_ChatLieu,Chatlieu")] ChatLieu chatLieu)
        {
            if (ModelState.IsValid)
            {
                chatLieu.ID_ChatLieu = Guid.NewGuid();
                _context.Add(chatLieu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chatLieu);
        }

        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.ChatLieu == null)
            {
                return NotFound();
            }

            var chatLieu = await _context.ChatLieu.FindAsync(id);
            if (chatLieu == null)
            {
                return NotFound();
            }
            return View(chatLieu);
        }

        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ID_ChatLieu,Chatlieu")] ChatLieu chatLieu)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chatLieu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChatLieuExists(chatLieu.ID_ChatLieu))
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
            return View(chatLieu);
        }

        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.ChatLieu == null)
            {
                return NotFound();
            }

            var chatLieu = await _context.ChatLieu
                .FirstOrDefaultAsync(m => m.ID_ChatLieu == id);
            if (chatLieu == null)
            {
                return NotFound();
            }

            return View(chatLieu);
        }

        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.ChatLieu == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ChatLieu'  is null.");
            }
            var chatLieu = await _context.ChatLieu.FindAsync(id);
            if (chatLieu != null)
            {
                _context.ChatLieu.Remove(chatLieu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChatLieuExists(Guid id)
        {
          return (_context.ChatLieu?.Any(e => e.ID_ChatLieu == id)).GetValueOrDefault();
        }
    }
}
