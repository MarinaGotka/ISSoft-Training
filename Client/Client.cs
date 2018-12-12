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
                Converter webServiceConverter = new Converter();
                string key;

                while (true)
                {
                    Console.WriteLine("For adding data enter 1, for displaying all results enter another character:  ");
                    key = Console.ReadLine();
                    if (key.Equals("1"))
                    {
                        Console.WriteLine("Enter the initial system measurement: ");
                        string systemFrom = Console.ReadLine();
                        Console.WriteLine("Enter the final system measurement: ");
                        string systemTo = Console.ReadLine();
                        Console.WriteLine("Enter the value to convert: ");
                        string value = Console.ReadLine();
                        SendCommand(webServiceConverter, systemFrom, systemTo, value);
                    }
                    else
                    {
                        Console.WriteLine(GetResult(webServiceConverter));
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static bool SendCommand(Converter webServiceConverter, string systemFrom, string systemTo, string value)
        {
           return webServiceConverter.Conveter(systemFrom, systemTo, value);
        }

        public static string GetResult(Converter webServiceConverter)
        {
            return webServiceConverter.ShowResults();
        }
    }
}
