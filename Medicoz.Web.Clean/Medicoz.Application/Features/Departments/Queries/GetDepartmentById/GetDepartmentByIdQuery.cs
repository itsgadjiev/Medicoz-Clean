using MediatR;
using Medicoz.Application.Features.Departments.Commands.UpdateDepartment;
using Medicoz.Domain;

namespace Medicoz.Application.Features.Departments.Queries.GetDepartmentById
{
    public class GetDepartmentByIdQuery : IRequest<UpdateDepartmentCommand>
    {
        public string DepartmentId { get; set; }
    }

}
