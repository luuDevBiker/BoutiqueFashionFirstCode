using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iot.Core.Infrastructure.Exceptions;

namespace BUS.Exceptions
{
    public class ForbidException : BusinessException
    {
        public ForbidException(string context, string message) : base(context, "Forbidden", 403, message)
        {
        }
    }
}
