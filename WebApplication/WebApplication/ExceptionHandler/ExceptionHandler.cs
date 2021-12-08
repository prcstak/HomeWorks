using System;
using Microsoft.Extensions.Logging;

namespace WebApplication.ExceptionHandler
{
    public class ExceptionHandler: IExceptionHandler, IExceptionHandler<Exception>
    {
        private ILogger Logger;

        protected ExceptionHandler(ILogger logger)
        {
            Logger = logger;
        }

        public void HandleException<T>(T exception) where T : Exception
        {
            var handler = this as IExceptionHandler<T>;
            if(handler != null)
                handler.Handle(exception);
            else
                this.Handle(exception as dynamic);
        }
        
        public void Handle(Exception exception)
        {
            OnFallback(exception);
        }

        protected virtual void OnFallback(Exception exception)
        {
            Logger.LogError($"Unidentified exception {exception}");
        }
    }
}