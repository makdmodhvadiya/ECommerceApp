using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.ViewModel
{
    public class ProductViewModel
    {
        public ProductViewModel()
        {
            ProductAttribute = new List<ProductAttributeViewModel>();
        }

        public long ProductId { get; set; }
        public int ProdCatId { get; set; }
        [Required]
        [StringLength(250)]
        public string ProdName { get; set; }
        public string ProdDescription { get; set; }
        public string ProdCatagory { get; set; }
        public List<ProductAttributeViewModel> ProductAttribute { get; set; }
    }

    public class ProductAttributeViewModel
    {
        public int AttributeId { get; set; }
        public string AttributeName { get; set; }
        [StringLength(250)]
        public string AttributeValue { get; set; }
    }
}
