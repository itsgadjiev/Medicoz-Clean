using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsQuery :IRequest<List<ProductListDTO>>
    {
        public GetAllProductsQuery(string sortField,string filterField)
        {
            SortField = sortField;
            FilterField = filterField;
        }

        public string SortField { get; set; }
        public string FilterField { get; set; }

    }
}
