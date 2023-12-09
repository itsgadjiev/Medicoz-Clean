using MediatR;
using Medicoz.Application.ViewModels.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Doctor.Queries.GetDoctorsList
{
    public class GetDoctorsListQuery : IRequest<List<DoctorListVMForAP>>
    {

    }
}
