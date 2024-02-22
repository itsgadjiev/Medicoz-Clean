using Medicoz.Domain.Common.concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Domain
{
    public class Blog :BaseEntity
    {
        public Dictionary<string, string> Title { get; set; }
        public Dictionary<string, string> Detail { get; set; }
        public string ImageUrl { get; set; }
        public string ApplicationUserId { get; set; }
        public string CreatorName { get; set; }
        public string CreatorSurname { get; set; }
        public string CreatorRole{ get; set; }

    }
}
