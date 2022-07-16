using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.Utility;
using Spice.Models.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class MenuItemsController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment webHostEnvironment;

        [BindProperty]
        public MenuItemViewModel MenuItemVM { get; set; }


        public MenuItemsController(ApplicationDbContext db,IWebHostEnvironment webHostEnvironment)
        {
            this.db = db;
            this.webHostEnvironment = webHostEnvironment;
            MenuItemVM = new MenuItemViewModel()
            {
                MenuItem = new MenuItem(),
                CategoryList=db.Categories.ToList()
            };   
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var MenuItemList = await db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToListAsync();
            return View(MenuItemList);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View(MenuItemVM);
        }
        [HttpPost]
        [ActionName("Create")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePost()
        {
            if (ModelState.IsValid)
            {
                
                string imagepath = @"/images/3.png";
                var files = HttpContext.Request.Form.Files;
                if(files.Count > 0)
                {
                    string WebRootPath = webHostEnvironment.WebRootPath;
                    string ImageName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);
                    FileStream filestream = new FileStream(Path.Combine(WebRootPath, "images",ImageName), FileMode.Create);
                    files[0].CopyTo(filestream);
                    imagepath = @"\images\"+ImageName;
                    
                }
                MenuItemVM.MenuItem.Image = imagepath;
                db.MenuItems.Add(MenuItemVM.MenuItem);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(MenuItemVM);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int ?id)
        {
            if(id== null)
            {
                return NotFound();
            }
            var menuitem=db.MenuItems.Include(m=>m.Category).Include(m=>m.SubCategory).FirstOrDefault(m=>m.Id==id);
            if (menuitem == null)
            {
                return NotFound();
            }
            MenuItemVM.MenuItem= menuitem;  
            MenuItemVM.SubCategoryList=await db.subCategories.Where(m=>m.CategoryId==MenuItemVM.MenuItem.CateogryId).ToListAsync();
            return View(MenuItemVM);
        }
        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost()
        {
            if (ModelState.IsValid)
            {

                string imagepath = MenuItemVM.MenuItem.Image;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    string WebRootPath = webHostEnvironment.WebRootPath;
                    string ImageName = DateTime.Now.ToFileTime().ToString() + Path.GetExtension(files[0].FileName);
                    FileStream filestream = new FileStream(Path.Combine(WebRootPath, "images", ImageName), FileMode.Create);
                    files[0].CopyTo(filestream);
                    imagepath = @"\images\" + ImageName;

                }
                MenuItemVM.MenuItem.Image = imagepath;
                db.MenuItems.Update(MenuItemVM.MenuItem);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(MenuItemVM);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var menuitem = db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).FirstOrDefault(m => m.Id == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            MenuItemVM.MenuItem = menuitem;
            MenuItemVM.SubCategoryList = await db.subCategories.Where(m => m.CategoryId == MenuItemVM.MenuItem.CateogryId).ToListAsync();
            return View(MenuItemVM);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var menuitem = db.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).FirstOrDefault(m => m.Id == id);
            if (menuitem == null)
            {
                return NotFound();
            }
            MenuItemVM.MenuItem = menuitem;
            MenuItemVM.SubCategoryList = await db.subCategories.Where(m => m.CategoryId == MenuItemVM.MenuItem.CateogryId).ToListAsync();
            return View(MenuItemVM);
        }
        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            db.MenuItems.Remove(MenuItemVM.MenuItem);
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
