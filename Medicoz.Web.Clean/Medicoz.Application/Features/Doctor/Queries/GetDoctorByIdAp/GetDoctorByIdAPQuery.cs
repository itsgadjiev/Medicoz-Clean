using MediatR;
using Medicoz.Application.Features.Doctor.Commands.UpdateDoctor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Doctor.Queries.GetDoctorByIdAp
{
    public class GetDoctorByIdAPQuery : IRequest<UpdateDoctorCommand>
    {
        public string DoctorId { get; set; }

        public GetDoctorByIdAPQuery(string doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
