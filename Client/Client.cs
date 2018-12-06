using System;
using WebServiceTask;

namespace ConsoleClient
{
    /// <summary>
    /// Class for clients working with web service 
    /// </summary>
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                string key;
                Converter webServiceConverter = new Converter();

                do
                {
                    Console.WriteLine("Enter the initial system measurement: ");
                    string systemFrom = Console.ReadLine();
                    Console.WriteLine("Enter the final system measurement: ");
                    string systemTo = Console.ReadLine();
                    Console.WriteLine("Enter the value to convert: ");
                    string value = Console.ReadLine();

                    webServiceConverter.Conveter(systemFrom, systemTo, value);

                    Console.WriteLine("For adding data enter 1, for displaying all results enter another character:  ");
                    key = Console.ReadLine();
                }
                while (key == "1");

                Console.WriteLine(webServiceConverter.ShowResults());
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
