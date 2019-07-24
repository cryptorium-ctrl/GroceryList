using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GroceryList.Data;
using GroceryList.Models;
using GroceryList.Models.ViewModel;
using GroceryList.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GroceryList.Controllers
{
    [Area("Admin")]
    public class ListsController : Controller
    {//Connect to DB
        private readonly ApplicationDbContext _db;
        private readonly HostingEnvironment _hostingEnvironment;

        [BindProperty]
        public ListsViewModel ListsVM { get; set; }


        public ListsController(ApplicationDbContext db, HostingEnvironment hostingEnvironment)
        {
            _db = db;
            _hostingEnvironment = hostingEnvironment;
            ListsVM = new ListsViewModel()
            {
                Products = _db.Products.ToList(),
                Lists = new Models.Lists()

            };
        }

        public async Task<IActionResult> Index()
        {
            return View(await _db.Lists.ToListAsync());
        }

        //GET Create Action Method
        public IActionResult Create()
        {
            return View();
        }

        //POST Create Action Method 
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Create(Lists lists) 
        {
            if(ModelState.IsValid)
            {

                _db.Add(lists);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lists);
        }

        //GET Edit Method
        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var lists = await _db.Lists.FindAsync(id);
            if(lists == null)
            {
                return NotFound();
            }

            return View(lists);
        }

        //POST Edit Method
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Edit(int id, Lists lists)
        {
            if(id != lists.Id)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _db.Update(lists);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lists);
        }

        //GET Details Method
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ListsVM.Lists = await _db.Lists.SingleOrDefaultAsync(m => m.Id == id);

            if (ListsVM.Lists == null)
            {
                return NotFound();
            }

            return View(ListsVM);
        }

        //GET Delete Action Method
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
            {
                return NotFound();
            }

            var lists = await _db.Lists.FindAsync(id);
            if(lists==null)
            {
                return NotFound();
            }

            return View(lists);
        }

        //POST Delete Method
        [HttpPost, ActionName("Delete")]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var lists = await _db.Lists.FindAsync(id);
            _db.Lists.Remove(lists);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //GET View on Products List
        public async Task<IActionResult> Products()
        {
            var products = _db.Products;
            return View(await products.ToListAsync());
        }

    }

    
}