using DuAnTotNghiep.Data;
using DuAnTotNghiep.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnTotNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/LoaiSanPham")]
    public class LoaiSanPhamController : Controller
    {
        // GET: LoaiSanPhamController
        ApplicationDbContext context;
        public LoaiSanPhamController()
        {
            context = new ApplicationDbContext();
        }

        [Route("Index")]
        public ActionResult Index()
        {
            var loaisp= context.LoaiSP.ToList();
            return View(loaisp);
        }

        [Route("Details")]
        // GET: LoaiSanPhamController/Details/5
        public ActionResult Details(Guid id)
        {
            var ct = context.LoaiSP.Find(id);
            return View(ct);
        }

        [Route("Create")]
        // GET: LoaiSanPhamController/Create
       
        public ActionResult Create()
        {
            return View();
        }

        [Route("Create")]
        // POST: LoaiSanPhamController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoaiSP loaisp)
        {
            try
            {
                context.LoaiSP.Add(loaisp);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [Route("Edit")]
        // GET: LoaiSanPhamController/Edit/5
        public ActionResult Edit(Guid id)
        {
            var sp = context.LoaiSP.Find(id);   
            return View(sp);
        }

        // POST: LoaiSanPhamController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LoaiSP loaisp)
        {
            try
            {
                var sp = context.LoaiSP.Find(loaisp.ID_LoaiSp);
                sp.ID_LoaiSp = loaisp.ID_LoaiSp;
                sp.Loai = loaisp.Loai;
                
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        [Route("Delete")]

        // GET: LoaiSanPhamController/Delete/5
        public ActionResult Delete(Guid id)
        {
           var xoa =  context.LoaiSP.Find(id);
            context.LoaiSP.Remove(xoa);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // POST: LoaiSanPhamController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
