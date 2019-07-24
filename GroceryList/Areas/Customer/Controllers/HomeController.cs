using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GroceryList.Models;
using GroceryList.Data;
using Microsoft.EntityFrameworkCore;
using GroceryList.Extensions;

namespace GroceryList.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        //Dependency injection to connect with DB
        //Start

        private readonly ApplicationDbContext _db;
        

        public HomeController(ApplicationDbContext db) //Constructor
        {
            _db = db;
        }

        public async Task<IActionResult> Index()
        {
            var productlist = await _db.Products.Include(m => m.ProductTypes).ToListAsync();

            return View(productlist);
        }
        //Finish

        
        public async Task<IActionResult> Details(int id)
        {
            var product = await _db.Products.Include(m => m.ProductTypes).Where(m => m.Id == id).FirstOrDefaultAsync();

            return View(product);
        }

        [HttpPost, ActionName("Details")]
        [ValidateAntiForgeryToken]
        public IActionResult DetailsPost(int id)
        {
            List<int> lstShoppingList = HttpContext.Session.Get<List<int>>("ssShoppingList");
            if (lstShoppingList == null)
            {
                lstShoppingList = new List<int>();
            }
            lstShoppingList.Add(id);
            HttpContext.Session.Set("ssShoppingList", lstShoppingList);

            return RedirectToAction("Index", "Home", new { area = "Customer" });

        }


        public IActionResult Remove(int id)
        {
            List<int> lstShoppingList = HttpContext.Session.Get<List<int>>("ssShoppingList");
            if ((lstShoppingList != null) && (lstShoppingList.Any()))
            {
                if (lstShoppingList.Contains(id))
                {
                    lstShoppingList.Remove(id);
                }
            }

            HttpContext.Session.Set("ssShoppingList", lstShoppingList);

            return RedirectToAction(nameof(Index));
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
