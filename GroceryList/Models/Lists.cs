using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GroceryList.Models
{
    public class Lists
    {
        public static Products Products { get; internal set; }
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
