using Medicoz.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Medicoz.Application.Contracts.Invoice
{
    public interface IInvoiceCreator
    {
        FileContentResult GenerateInvoice(Order order);
    }
}
