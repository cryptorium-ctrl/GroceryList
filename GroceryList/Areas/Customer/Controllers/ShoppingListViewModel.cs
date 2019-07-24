using System.Collections.Generic;
using GroceryList.Models;

namespace GroceryList.Areas.Customer.Controllers
{
    public class ShoppingListViewModel
    {
        public List<Products> Products { get; internal set; }
    }
}