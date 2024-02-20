namespace Medicoz.Application.Features.Products.Queries.GetProductByIdDetail
{
    public class ProductDetailDTO
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public string ImageUrl { get; set; }
    }
}
