using System;

namespace MyLogger
{
	public sealed class WriteToRegistry : ILogger
	{
		private static readonly WriteToRegistry Instance = new WriteToRegistry();

		private WriteToRegistry() { }

		public static WriteToRegistry GetInstance
		{
			get
			{
				return Instance;
			}
		}


		public void LogTo(string GetLogName, string GetText)
		{
			try
			{
				Microsoft.Win32.RegistryKey MyLoggerRegistery;
				MyLoggerRegistery = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("MyLoggerRegistery");
				MyLoggerRegistery.SetValue(GetLogName, GetText);
				MyLoggerRegistery.Close();
			}
			catch (Exception e)
			{
				Console.WriteLine("Zapis do Edytora rejestru nie powiódł się");
				Console.WriteLine(e.Message);
			}
			Console.WriteLine("Dokonano wpisu do rejestru: HKEY_CURRENT_USER/MyLoggerRegistery");
		}
	}
}
