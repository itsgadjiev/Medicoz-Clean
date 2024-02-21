using MediatR;
using Medicoz.Application.Contracts.Localisation;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.Features.Departments.Queries.GetAllDepartments;
using Medicoz.Domain;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Products.Queries.GetAllProducts
{

    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductListDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;

        }

        public async Task<List<ProductListDTO>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var sortField = request.SortField;
            var filterField = request.FilterField;

            var query = _productRepository.GetAllAsQueryable();

            if (!string.IsNullOrEmpty(filterField))
            {
                query = query.Where(x => x.Name.Contains(filterField));
            }

            if (!string.IsNullOrEmpty(sortField))
            {
                switch (sortField.ToLower())
                {
                    case "price":
                        query = query.OrderBy(e => e.Price);
                        break;
                    case "pricedesc":
                        query = query.OrderByDescending(e => e.Price);
                        break;
                    case "newness":
                        query = query.OrderBy(e => e.CreatedAt);
                        break;
                    case "rating":
                        query = query.OrderByDescending(e => e.Point);
                        break;
                    default:
                        query = query.OrderBy(e => e.Id);
                        break;
                }
            }
            else
            {
                query = query.OrderBy(e => e.Id);
            }


            var departmetsListDto = query.Select(x => new ProductListDTO
            {
                Description = x.Description,
                Name = x.Name,
                Id = x.Id,
                ImageUrl = x.ImageUrl,
                Price = x.Price,
                Point = x.Point,

            }).ToList();

            return departmetsListDto;
        }
    }
}
