using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.DAL.Model
{
    public partial class ProductAttribute
    {
        //[Key]
        //public int ProductAttributeId { get; set; }
        public long ProductId { get; set; }
        public int AttributeId { get; set; }
        [StringLength(250)]
        public string AttributeValue { get; set; }

        [ForeignKey("AttributeId")]
        [InverseProperty("ProductAttribute")]
        public virtual ProductAttributeLookup Attribute { get; set; }
        [ForeignKey("ProductId")]
        [InverseProperty("ProductAttribute")]
        public virtual Product Product { get; set; }
    }
}
