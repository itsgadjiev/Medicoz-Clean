using MediatR;

namespace Medicoz.Application.Features.Doctor.Commands.AddDoctor
{
    public class AddDoctorCommandHandler : IRequestHandler<AddDoctorCommand, Unit>
    {
        public AddDoctorCommandHandler()
        {
                
        }
        public Task<Unit> Handle(AddDoctorCommand request, CancellationToken cancellationToken)
        {
            
        }

        public List<DateTime> GetHourlyIntervals(DateTime startDateTime, DateTime endDateTime)
        {
            if (startDateTime >= endDateTime)
            {
                throw new ArgumentException("Start date should be earlier than end date.");
            }

            List<DateTime> intervals = new List<DateTime>();
            intervals.Add(startDateTime);

            DateTime currentInterval = startDateTime;

            while (currentInterval < endDateTime)
            {
                currentInterval = currentInterval.AddHours(1);
                if (currentInterval <= endDateTime)
                {
                    intervals.Add(currentInterval);
                }
            }

            return intervals;
        }
    }
}
