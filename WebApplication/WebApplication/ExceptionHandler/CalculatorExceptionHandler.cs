using System;
using Microsoft.Extensions.Logging;

namespace WebApplication.ExceptionHandler
{
    public class CalculatorExceptionHandler: 
        ExceptionHandler,
        IExceptionHandler<ArgumentNullException>,
        IExceptionHandler<DivideByZeroException>,
        IExceptionHandler<InvalidOperationException>
    {
        private ILogger Logger;
        public CalculatorExceptionHandler(ILogger logger) : base(logger)
        {
        }
        
        public void Handle(ArgumentNullException e)
        {
            Logger.LogError($"ArgumentNullException");
        }

        public void Handle(DivideByZeroException e)
        {
            Logger.LogError($"DivideByZeroException");
        }

        public void Handle(InvalidOperationException e)
        {
            Logger.LogError($"InvalidOperationException");
        }
    }
}