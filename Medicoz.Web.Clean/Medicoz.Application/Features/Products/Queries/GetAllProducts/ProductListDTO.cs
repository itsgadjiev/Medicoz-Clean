namespace Medicoz.Application.Features.Products.Queries.GetAllProducts
{
    public class ProductListDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Point { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
