using MediatR;
using Medicoz.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.DoctorDetail.Queries.GetDoctorDetail
{
    public class GetDoctorDetailQuery : IRequest<DoctorDetailViewModel>
    {
        public string DoctorId { get; set; }
        
    }
}
