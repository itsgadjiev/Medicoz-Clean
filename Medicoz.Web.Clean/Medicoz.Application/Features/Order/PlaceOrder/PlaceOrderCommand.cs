using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Order.PlaceOrder
{
    public class PlaceOrderCommand : IRequest<StatusCodeResult>
    {
        public HttpContext HttpContext { get; set; }
        public Domain.Order Order { get; set; }
        public IWebHost IWebHost { get; set; }

    }
}
