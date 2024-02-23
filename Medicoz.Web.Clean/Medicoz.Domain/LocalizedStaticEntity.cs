using Medicoz.Domain.Common.concrets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Domain
{
    public class LocalizedStaticEntity : BaseEntity
    {
        public string Key { get; set; }
        public Dictionary<string,string> Value { get; set; }
    }
}
