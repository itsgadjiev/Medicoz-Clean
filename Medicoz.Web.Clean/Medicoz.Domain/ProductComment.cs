using Medicoz.Domain.Common.concrets;

namespace Medicoz.Domain
{
    public class ProductComment :BaseEntity
    {
        public string Review { get; set; }
        public string PostingUserName { get; set; }
        public string PostingUserEmail { get; set; }
        public string ProductId { get; set; }
        public Product Product { get; set; }
    }
}
