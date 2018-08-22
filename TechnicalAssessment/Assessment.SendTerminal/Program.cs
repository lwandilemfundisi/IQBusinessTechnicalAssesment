using System;

namespace Assessment.SendTerminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a message below..");
            string line = string.Empty;

            do
            {
                line = Console.ReadLine();
                if (line != "quit")
                {
                    var responseTask = SendMessageApp.Instance.ExecuteCommand(new SendMessageCommad
                    {
                        Content = line
                    });

                    var response = responseTask.Result;
                }
                
            }
            while (line != "quit");

            Console.Read();
        }
    }
}
