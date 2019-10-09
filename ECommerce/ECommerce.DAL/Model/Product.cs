using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.DAL.Model
{
    public partial class Product
    {
        public Product()
        {
            ProductAttribute = new HashSet<ProductAttribute>();
        }

        [Key]
        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        [Required]
        [StringLength(250)]
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }

        [ForeignKey("ProdCatId")]
        [InverseProperty("Product")]
        public virtual ProductCategory ProdCatagory { get; set; }
        [InverseProperty("Product")]
        public virtual ICollection<ProductAttribute> ProductAttribute { get; set; }
    }
}
