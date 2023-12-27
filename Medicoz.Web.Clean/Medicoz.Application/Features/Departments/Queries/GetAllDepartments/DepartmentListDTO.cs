using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Departments.Queries.GetAllDepartments
{
    public  class DepartmentListDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Detail { get; set; }
        public string ImageURL { get; set; }
        public string Icon { get; set; }
    }
}
