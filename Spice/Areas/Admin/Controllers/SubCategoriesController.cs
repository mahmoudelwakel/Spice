using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spice.Data;
using Spice.Models;
using Spice.Models.Utility;
using Spice.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Areas.Admin.Controllers
{
    [Authorize(Roles = SD.ManagerUser)]
    [Area("Admin")]
    public class SubCategoriesController : Controller
    {
        private readonly ApplicationDbContext db;
        [TempData]
        public string StatusMessege { get; set; }
        public SubCategoriesController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            var subCategory = await db.subCategories.Include("Category").ToListAsync();
            return View(subCategory);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await db.Categories.ToListAsync(),
                SubCategory = new Models.SubCategory(),
               // SubCategoryList = await db.subCategories.OrderBy(n => n.Name).Select(n => n.Name).Distinct().ToListAsync()

            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesExsitsSubCategory =await  db.subCategories.Include(m => m.Category).Where(m => m.CategoryId == model.SubCategory.CategoryId && m.Name == model.SubCategory.Name).ToListAsync();

                if (doesExsitsSubCategory.Count()>0) {
                    StatusMessege = "Error: this SubCategory Is Exist Under " + doesExsitsSubCategory.FirstOrDefault().Category.Name;
                }
                else {
                    db.subCategories.Add(model.SubCategory);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index)); }

            }

            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await db.Categories.ToListAsync(),
                SubCategory = model.SubCategory,
               // SubCategoryList = await db.subCategories.OrderBy(n => n.Name).Select(n => n.Name).Distinct().ToListAsync(),
                StatusMessege=StatusMessege

            };
            return View(modelVM);

        }
        [HttpGet]
        public async Task<IActionResult>GetSubCategories(int id)
        {
            List<SubCategory> SubCategoryList = new List<SubCategory>();
            SubCategoryList =await db.subCategories.Where(m => m.CategoryId == id).ToListAsync();
            return Json(new SelectList(SubCategoryList, "Id", "Name"));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var SubCategory = await db.subCategories.FindAsync(id);
            if(SubCategory == null)
            {
                return NotFound();
            }
            SubCategoryAndCategoryViewModel model = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await db.Categories.ToListAsync(),
                SubCategory = SubCategory,
                // SubCategoryList = await db.subCategories.OrderBy(n => n.Name).Select(n => n.Name).Distinct().ToListAsync()

            };
            return View(model);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(SubCategoryAndCategoryViewModel model)
        {
            if (ModelState.IsValid)
            {
                var doesExsitsSubCategory = await db.subCategories.Include(m => m.Category).Where(m => m.CategoryId == model.SubCategory.CategoryId && m.Name == model.SubCategory.Name &&m.Id !=model.SubCategory.Id).ToListAsync();

                if (doesExsitsSubCategory.Count() > 0)
                {
                    StatusMessege = "Error: this SubCategory Is Exist Under " + doesExsitsSubCategory.FirstOrDefault().Category.Name;
                }
                else
                {
                    db.subCategories.Update(model.SubCategory);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }

            SubCategoryAndCategoryViewModel modelVM = new SubCategoryAndCategoryViewModel()
            {
                CategoryList = await db.Categories.ToListAsync(),
                SubCategory = model.SubCategory,
                // SubCategoryList = await db.subCategories.OrderBy(n => n.Name).Select(n => n.Name).Distinct().ToListAsync(),
                StatusMessege = StatusMessege

            };
            return View(modelVM);

        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var doesSubCategoryExsist=db.subCategories.Include(m=>m.Category).Where(m=>m.Id==id).FirstOrDefault(); 
            if(doesSubCategoryExsist == null)
            {
                return NotFound();
            }
            return View(doesSubCategoryExsist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(SubCategory subcategory)
        {
                db.subCategories.Remove(subcategory);
               await db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult>Details(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var subCategory =await db.subCategories.Include(m=>m.Category).Where(m=>m.Id==id).FirstOrDefaultAsync(); 
            if(subCategory == null)
            {
                return NotFound();
            }
            return View(subCategory);
        }
      
    }
}
