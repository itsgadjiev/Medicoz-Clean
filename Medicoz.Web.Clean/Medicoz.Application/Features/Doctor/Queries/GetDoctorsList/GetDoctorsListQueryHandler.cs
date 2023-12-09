using MediatR;
using Medicoz.Application.Contracts.Percistance;
using Medicoz.Application.ViewModels.Areas.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Doctor.Queries.GetDoctorsList
{
    public class GetDoctorsListQueryHandler : IRequestHandler<GetDoctorsListQuery, List<DoctorListVMForAP>>
    {
        private readonly IDoctorRepository _doctorRepository;

        public GetDoctorsListQueryHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<DoctorListVMForAP>> Handle(GetDoctorsListQuery request, CancellationToken cancellationToken)
        {
            var doctors = await _doctorRepository.GetAllAsync(); 

            var doctorViewModels = doctors.Select(doctor => new DoctorListVMForAP
            {
                Name = doctor.Name,
                Surname = doctor.Surname,
                Title = doctor.Title, 
                Fee = doctor.Fee
            }).ToList();

            return doctorViewModels;
        }
    }
}
