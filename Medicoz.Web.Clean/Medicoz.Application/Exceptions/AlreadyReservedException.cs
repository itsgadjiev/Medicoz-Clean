using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicoz.Application.Exceptions
{
    public class AlreadyReservedException : ApplicationException
    {
        public string Key { get; set; }
        public string ErrorMessage { get; set; }

        public AlreadyReservedException(string key, string errorMessage)
        {
            Key = key;
            ErrorMessage = errorMessage;
        }

        public AlreadyReservedException(string errorMessage)
        {
            Key = string.Empty;
            ErrorMessage = errorMessage;
        }
    }
}
