using System;

namespace Assessment.SendTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a message below..");
            var line = Console.ReadLine();

            var responseTask = SendMessageApp.Instance.ExecuteCommand(new SendMessageCommad
            {
                Content = line
            });

            var response = responseTask.Result;

            Console.Read();
        }


    }
}
