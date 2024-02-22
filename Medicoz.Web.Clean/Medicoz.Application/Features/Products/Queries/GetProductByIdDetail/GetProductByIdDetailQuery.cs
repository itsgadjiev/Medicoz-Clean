using MediatR;
using Medicoz.Application.Features.Products.Commands.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Products.Queries.GetProductByIdDetail
{
    public class GetProductByIdQueryDetail : IRequest<ProductDetailDTO>
    {
        public string Id { get; set; }
    }
}
