using System;
using System.Security;

namespace MyLogger
{
	public sealed class RegistryLogger : ILogger
	{
		public void LogTo(string GetLogName, string GetText)
		{
			try
			{
				Microsoft.Win32.RegistryKey MyLoggerRegistery;
				MyLoggerRegistery = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("MyLoggerRegistery");
				MyLoggerRegistery.SetValue(GetLogName, GetText);
				MyLoggerRegistery.Close();
			}
			catch (SecurityException se)
			{
				Console.WriteLine("Nie posiadasz odpowiednich uprawnien do tworzenia wpisu w rejestrze");
				Console.WriteLine(se.Message);
			}
			catch (Exception e)
			{
				Console.WriteLine("Zapis do rejestru nie powiodł się");
				Console.WriteLine(e.Message);
			}
			Console.WriteLine("Dokonano wpisu do rejestru: HKEY_CURRENT_USER/MyLoggerRegistery");			
		}
	}
}
