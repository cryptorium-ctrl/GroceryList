using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroceryList.Data;
using GroceryList.Extensions;
using GroceryList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GroceryList.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class ShoppingListController : Controller
    {

        private readonly ApplicationDbContext _db;

        [BindProperty]
        public  ShoppingListViewModel ShoppingListVM { get; set; }
       
        public ShoppingListController(ApplicationDbContext db)
        {
            _db = db;
            ShoppingListVM = new ShoppingListViewModel
            {
                Products = new List<Models.Products>()
            };
        }

        //GET Index ShoppingList
        public async Task<IActionResult> Index()
        {
            
            List<int> lstShoppingList = HttpContext.Session.Get<List<int>>("ssShoppingList");
            if ((lstShoppingList != null) && (lstShoppingList.Any()))
            {
                foreach(int listItem in lstShoppingList)
                {
                    Products prod = _db.Products.Include(p => p.ProductTypes).Where(p => p.Id == listItem).FirstOrDefault();
                    ShoppingListVM.Products.Add(prod);
                }
            }
            return View(ShoppingListVM);
        }
    }
}