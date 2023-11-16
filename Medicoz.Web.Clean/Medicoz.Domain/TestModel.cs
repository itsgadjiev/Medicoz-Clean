using Medicoz.Domain.Common.concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Domain
{
    public class TestModel:BaseEntity
    {
        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Description { get; set; }
    }
}
