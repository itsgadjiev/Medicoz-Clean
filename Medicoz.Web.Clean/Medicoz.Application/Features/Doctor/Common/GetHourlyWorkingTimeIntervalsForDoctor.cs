using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Features.Doctor.Common
{
    public class GetHourlyWorkingTimeIntervalsForDoctor
    {
        public readonly int DoctorAcceptanceTime = 1;
        public List<DateTime> Handle(DateTime startDateTime, DateTime endDateTime)
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
                currentInterval = currentInterval.AddHours(DoctorAcceptanceTime);
                if (currentInterval <= endDateTime)
                {
                    intervals.Add(currentInterval);
                }
            }

            return intervals;
        }
    }
}
