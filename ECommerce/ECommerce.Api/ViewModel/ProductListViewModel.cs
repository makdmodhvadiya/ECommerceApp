using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Api.ViewModel
{
    public class ProductListViewModel
    {
        public ProductListViewModel()
        {
            Products = new List<ProductViewModel>();
        }

        public long TotalCount { get; set; }
        public List<ProductViewModel> Products { get; set; }
    }
}
