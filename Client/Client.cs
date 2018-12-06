using System;
using WebServiceTask;

namespace ConsoleClient
{
    /// <summary>
    /// Class for clients working with web service 
    /// </summary>
    class Client
    {
        public delegate string Result();
        public event Result EventGetResult;

        static void Main(string[] args)
        {
            try
            { 
                Converter webServiceConverter = new Converter();
                string key;

                Result result = webServiceConverter.ShowResults;

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
                        webServiceConverter.Conveter(systemFrom, systemTo, value);
                    }
                    else
                    {
                        Console.WriteLine(result);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
