using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicromarinCase.Services.ExceptionHandler
{
    public class CriticalException(string message):Exception(message);

}
