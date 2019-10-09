using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.DAL.Model
{
    public partial class ProductAttributeLookup
    {
        public ProductAttributeLookup()
        {
            ProductAttribute = new HashSet<ProductAttribute>();
        }

        [Key]
        public int AttributeId { get; set; }
        public int ProdCatId { get; set; }
        [Required]
        [StringLength(250)]
        public string AttributeName { get; set; }

        [ForeignKey("ProdCatId")]
        [InverseProperty("ProductAttributeLookup")]
        public virtual ProductCategory ProdCatagory { get; set; }
        [InverseProperty("Attribute")]
        public virtual ICollection<ProductAttribute> ProductAttribute { get; set; }
    }
}
