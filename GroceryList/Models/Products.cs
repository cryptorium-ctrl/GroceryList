using GroceryList.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryList.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public bool Available { get; set; }

        public string Image { get; set; }

        public string ShadeColor { get; set; }

        [Display(Name = "Product Type")]
        public int ProductTypeId { get; set; }

        [ForeignKey("ProductTypeId")]
        public virtual ProductTypes ProductTypes { get; set; }

        private object products;

        public object GetProducts()
        {
            return products;
        }

        internal void SetProducts(object value)
        {
            products = value;
        }

        public static implicit operator Products(List<Products> v)
        {
            throw new NotImplementedException();
        }
    }
}