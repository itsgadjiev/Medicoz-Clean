using Medicoz.Application.Features.Products.Queries.GetAllProducts;
using Medicoz.Application.Features.Products.Queries.GetProductByIdDetail;

namespace Medicoz.MVC.ViewModels
{
    public class ShopViewModel
    {
        public List<ProductListDTO> ProductDetailDTOs { get; set; }
        public List<ProductListDTO> NewProductDetailDTOs { get; set; }
    }
}
