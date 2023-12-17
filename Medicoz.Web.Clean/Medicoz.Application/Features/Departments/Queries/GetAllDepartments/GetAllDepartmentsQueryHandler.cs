using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Departments.Queries.GetAllDepartments
{
    public class GetAllDepartmentsQueryHandler : IRequestHandler<GetAllDepartmentsQuery, List<Department>>
    {
        private readonly IDepartmentRepository _departmentRepository;

        public GetAllDepartmentsQueryHandler(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
       
        public async Task<List<Department>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAllAsync(); 
            return departments;
        }
    }
}
