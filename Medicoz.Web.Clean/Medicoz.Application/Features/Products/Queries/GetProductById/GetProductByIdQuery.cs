using MediatR;
using Medicoz.Application.Features.Products.Commands.UpdateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQuery :IRequest<UpdateProductCommand>
    {
        public string Id { get; set; }
    }
}
