using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.DAL.Model
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            Product = new HashSet<Product>();
            ProductAttributeLookup = new HashSet<ProductAttributeLookup>();
        }

        [Key]
        public int ProdCatId { get; set; }
        [StringLength(250)]
        public string CategoryName { get; set; }

        [InverseProperty("ProdCatagory")]
        public virtual ICollection<Product> Product { get; set; }
        [InverseProperty("ProdCatagory")]
        public virtual ICollection<ProductAttributeLookup> ProductAttributeLookup { get; set; }
    }
}
