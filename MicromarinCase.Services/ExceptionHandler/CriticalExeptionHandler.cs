using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace MicromarinCase.Services.ExceptionHandler
{
    public class CriticalExeptionHandler : IExceptionHandler
    {
        public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            if(exception is CriticalException)
            {
                //sms,mail vs gönderilebilir
                //Console.WriteLine("hata ile ilgili sms gönderildi");
            }

            return ValueTask.FromResult(false);
        }
    }
}
