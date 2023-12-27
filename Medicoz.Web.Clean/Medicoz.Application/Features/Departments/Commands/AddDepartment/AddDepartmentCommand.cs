using MediatR;
using Medicoz.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Departments.Commands.AddDepartment
{
    public class AddDepartmentCommand :IRequest<Unit>
    {
        public string NameAZ { get; set; }
        public string NameEN { get; set; }
        public string DetailAZ { get; set; }
        public string DetailEN { get; set; }
        public IFormFile Image { get; set; }
        public string Icon { get; set; }
        public string WebRootPath { get; set; }
    }
}
