using MediatR;
using Medicoz.Application.Features.Doctor.Commands.UpdateDoctor;

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
