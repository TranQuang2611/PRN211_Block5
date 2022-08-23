using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace WebMVC_EF.Models
{
    public partial class Product
    {
        public int ProductId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This string is empty")]
        public string ProductName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This string is empty")]
        public decimal? UnitPrice { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This string is empty")]
        public int? UnitsInStock { get; set; }
        public string Image { get; set; }
        public int? CategoryId { get; set; }
        public bool? Discontinued { get; set; }

        public virtual Category Category { get; set; }
    }
}
