using System;
using System.Threading.Tasks;

namespace Blauhaus.Errors.Handler
{
    public interface IErrorHandler
    {
        Task HandleExceptionAsync(object sender, Exception exception);
        Task HandleErrorAsync(string errorMessage);
        Task HandleErrorAsync(Error errorMessage);
    }
}