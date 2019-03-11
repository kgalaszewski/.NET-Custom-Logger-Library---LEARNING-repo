using System;
using System.Threading;

namespace MyLoggerApp.Services
{
    class HelperService
    {
        private static readonly HelperService _Instance = new HelperService();

        private HelperService() { }

        public static HelperService GetInstance()
        {
            return _Instance;
        }

        public void ClearConsoleAndWriteMessage(string msg)
        {
            Console.Clear();
            Console.WriteLine(msg);
        }

        public void EnsureThatActionSucceed(Action action, Action finallyAction, string errorMsg = "error message not implemented")
        {
            try
            {
                action.Invoke();
            }
            catch (Exception e)
            {
                ClearConsoleAndWriteMessage($"ErrorMessage : {errorMsg}\nSystemErrorMessage : {e.Message}");
                Thread.Sleep(500);
                Console.ReadKey();
            }
            finally
            {
                finallyAction.Invoke();
            }
        }
    }
}
