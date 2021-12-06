using System;
using Microsoft.Extensions.Logging;

namespace WebApplication.ExceptionHandler
{
    public interface IExceptionHandler
    {
        public void Handle(Exception e);
        void Aggregate(Exception exception);
    }
}