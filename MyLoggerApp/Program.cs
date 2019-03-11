namespace MyLogger
{
    class Program
	{
		static void Main(string[] args)
		{
            UserService.GetInstance().CreateNewUser();
        }
	}
}
