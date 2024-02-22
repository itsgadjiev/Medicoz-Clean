using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Order.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<Unit>
    {
        public HttpContext HttpContext { get; set; }
        public Domain.Order Order { get; set; }
    }
}
