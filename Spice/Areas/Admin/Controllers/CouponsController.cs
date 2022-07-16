using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.Utility;
using System.IO;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class CouponsController : Controller
    {
        private readonly ApplicationDbContext db;

        public CouponsController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var CouponsList = await db.Coupons.ToListAsync();
            return View(CouponsList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();  
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] Picture=null;
                    var fs = files[0].OpenReadStream();
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    Picture = ms.ToArray();
                    coupon.Picture = Picture;
                }
                db.Coupons.Add(coupon);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coupon);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var coupon = db.Coupons.Find(id);
            if(coupon == null)
            {
                return NotFound();
            }
            return View(coupon);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    byte[] Picture = null;
                    var fs = files[0].OpenReadStream();
                    var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    Picture = ms.ToArray();
                    coupon.Picture = Picture;
                }
                db.Coupons.Update(coupon);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coupon);

        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var coupon = db.Coupons.Find(id);
            if (coupon == null)
            {
                return NotFound();
            }
            return View(coupon);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Coupon coupon)
        {
            //if (ModelState.IsValid)
            //{
            //    var files = HttpContext.Request.Form.Files;
            //    if (files.Count > 0)
            //    {
            //        byte[] Picture = null;
            //        var fs = files[0].OpenReadStream();
            //        var ms = new MemoryStream();
            //        fs.CopyTo(ms);
            //        Picture = ms.ToArray();
            //        coupon.Picture = Picture;
            //    }
            //    db.Coupons.Update(coupon);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            db.Coupons.Remove(coupon);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
         

        }

    }
}
