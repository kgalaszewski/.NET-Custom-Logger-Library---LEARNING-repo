using MyLoggerApp.Services;
using System;

namespace MyLogger
{
    class Program
	{
		static void Main(string[] args)
		{
            HelperService.GetInstance().EnsureThatActionSucceed(() => 
            {
                UserService.GetInstance().CreateNewUser();
            }, 
            () => { Environment.Exit(0); }, "MyLoggerApp has stopped working");
        }
	}
}
