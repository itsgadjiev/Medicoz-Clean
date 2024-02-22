using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.Application.Contracts.Payment
{
    public interface IPaymentService
    {
        StatusCodeResult Charge(HttpContext httpContext, long? amount, string orderDetail);
    }
}
