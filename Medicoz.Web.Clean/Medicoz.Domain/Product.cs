using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public double Point { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public List<ProductComment> ProductComments { get; set; }
}
