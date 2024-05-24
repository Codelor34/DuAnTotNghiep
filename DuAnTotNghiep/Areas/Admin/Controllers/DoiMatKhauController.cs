using DuAnTotNghiep.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DuAnTotNghiep.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin")]
    [Route("Admin/DoiMatKhau")]
    public class DoiMatKhauController : Controller
    {

        ApplicationDbContext context;
        public DoiMatKhauController()
        {
            context = new ApplicationDbContext();
        }

        [Route("Index")]
        // GET: DoiMatKhauController
        public ActionResult Index()
        {

            return View();
        }

        // GET: DoiMatKhauController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DoiMatKhauController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DoiMatKhauController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: DoiMatKhauController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DoiMatKhauController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: DoiMatKhauController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DoiMatKhauController/Delete/5
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
