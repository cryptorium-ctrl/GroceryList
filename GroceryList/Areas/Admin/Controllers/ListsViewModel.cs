using System.Collections.Generic;
using GroceryList.Models;

namespace GroceryList.Controllers
{
    public class ListsViewModel
    {
        public List<Products> Products { get; internal set; }
        public Lists Lists { get; internal set; }
    }
}