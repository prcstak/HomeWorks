using System;
using Microsoft.Extensions.Logging;

namespace WebApplication.ExceptionHandler
{
    public interface IExceptionHandler
    {
        void HandleException<T>(T exception) where T : Exception;
    }

    public interface IExceptionHandler<T> where T : Exception
    {
        void Handle(T exception);
    }
}