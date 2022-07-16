using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models.Utility;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles =SD.ManagerUser)]
    
    [Area("Admin")]
   
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext db;

        public UsersController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var claimIdentity =(ClaimsIdentity)User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            string UserId = claim.Value;
            return View(await db.ApplicationUsers.Where(m=>m.Id !=UserId).ToListAsync());
        }
        public async Task<IActionResult> LockUnLock(string ? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user=await db.ApplicationUsers.Where(m=>m.Id == id).FirstOrDefaultAsync();  
            if(user == null)
            {
                return NotFound();
            }
            if(user.LockoutEnd==null || user.LockoutEnd < DateTime.Now)
            {
                user.LockoutEnd=DateTime.Now.AddDays(1000);
            }
            else
            {
                user.LockoutEnd = DateTime.Now;
            }
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
