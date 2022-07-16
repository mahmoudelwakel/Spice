using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.ViewModel;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Spice.Models.Utility;
using System.Collections.Generic;

namespace Spice.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext db;

        public HomeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claims= claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            if (claims != null)
            {
                List<ShoppingCart> shoppingcart = await db.ShoppingCarts.Where(m => m.ApplicationUserId == claims.Value).ToListAsync();
                HttpContext.Session.SetInt32(SD.ShoppingCartCount, shoppingcart.Count);
            }
            IndexViewModel IndexVM = new IndexViewModel()
            {
                Categories = await db.Categories.ToListAsync(),
                Coupons=await db.Coupons.Where(m=>m.IsActive==true).ToListAsync(), 
                MenuItems=await db.MenuItems.Include(m=>m.Category).Include(m=>m.SubCategory).ToListAsync()

            };
            return View(IndexVM);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult>Details(int itemid)
        {
            var menuitem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).Where(m=>m.Id== itemid).FirstOrDefaultAsync();
            ShoppingCart shoppingcart = new ShoppingCart()
            {
                MenuItem = menuitem,
                MenuItemId = menuitem.Id

            };
            return View(shoppingcart);  
        }
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Details(ShoppingCart shoppingcart)
        {
            if (ModelState.IsValid)
            {
               
                var claimsidentity = (ClaimsIdentity)User.Identity;
                var claim = claimsidentity.FindFirst(ClaimTypes.NameIdentifier);
                shoppingcart.ApplicationUserId = claim.Value;
                var shoppingCartFromDB = await db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingcart.ApplicationUserId && m.MenuItemId == shoppingcart.MenuItemId).FirstOrDefaultAsync();
                if (shoppingCartFromDB == null)
                {
                    db.ShoppingCarts.Add(shoppingcart);
                }
                else
                {
                    shoppingCartFromDB.Count += shoppingcart.Count;
                }
                await db.SaveChangesAsync();
                var count = db.ShoppingCarts.Where(m => m.ApplicationUserId == shoppingcart.ApplicationUserId).ToList().Count();
                HttpContext.Session.SetInt32(SD.ShoppingCartCount, count);
                return RedirectToAction(nameof(Index));
            }
            else
            {

                var menuitem = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).Where(m => m.Id == shoppingcart.MenuItemId).FirstOrDefaultAsync();
                ShoppingCart shoppingcartobj = new ShoppingCart()
                {
                    MenuItem = menuitem,
                    MenuItemId = menuitem.Id

                };
                return View(shoppingcartobj);
            }
        }
    }
}
