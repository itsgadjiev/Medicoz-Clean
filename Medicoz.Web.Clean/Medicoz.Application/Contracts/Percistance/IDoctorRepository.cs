using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Contracts.Percistance
{
    public interface IDoctorRepository : IGenericRepository<Domain.Doctor>
    {
    }
}
