using Medicoz.Application.Contracts.Percistance;
using Medicoz.Domain;
using Medicoz.Persistence.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Persistence.Repositories
{
    public class TestRepository :GenericRepository<TestModel>,ITestRepository
    {
        public TestRepository(AppDbContext appDbContext) :base(appDbContext) 
        {
            
        }
       
    }
}
