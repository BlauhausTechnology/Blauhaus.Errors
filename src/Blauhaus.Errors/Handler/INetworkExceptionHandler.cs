using System;

namespace Blauhaus.Errors.Handler
{
    public interface INetworkExceptionHandler
    {
        Error ExtractError(Exception exception);
    }
}