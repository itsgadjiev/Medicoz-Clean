using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace Medicoz.Persistence.Repositories;

public class DoctorDepartmentRepository : GenericRepository<DoctorDepartment>, IDoctorDepartmentRepository
{
    public DoctorDepartmentRepository(AppDbContext context) : base(context)
    {
       
    }
    public List<DoctorDepartment> FindDoctorDepartmentsByDoctorId(string doctorId)
    {
        return _context.DoctorDepartments
            .Include(dd => dd.Doctor)  
            .Include(dd => dd.Department)
            .ToList();
    }

    public async Task<List<DoctorDepartment>> GetAllAsyncIncluded()
    {
        return await _context.DoctorDepartments
            .Include(dd => dd.Department)
            .Include(dd => dd.Doctor)
            .ToListAsync();
    }
}
