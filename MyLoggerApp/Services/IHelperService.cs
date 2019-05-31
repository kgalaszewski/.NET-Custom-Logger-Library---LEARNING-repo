using System;

namespace MyLoggerApp.Services
{
    public interface IHelperService
    {
        void ClearConsoleAndWriteMessage(string msg);
        void DisplayEmptyLogParametersAlert(params string[] arguments);
        void EnsureThatActionSucceed(Action action, Action finallyAction, string errorMsg = "error message not implemented");
    }
}