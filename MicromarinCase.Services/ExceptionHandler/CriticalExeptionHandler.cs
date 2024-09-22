using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicromarinCase.Services.ExceptionHandler
{
    public class CriticalExeptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if(exception is CriticalException)
            {
                Console.WriteLine("hata ile ilgili sms gönderildi");
            }

            return ValueTask.FromResult(false);  //bir sonraki handlera uğra
        }
    }
}
