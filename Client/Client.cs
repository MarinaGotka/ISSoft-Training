using System;
using WebServiceTask;

namespace ConsoleClient
{
    class Client
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter the initial system measurement: ");
                string systemFrom = Console.ReadLine();
                Console.WriteLine("Enter the final system measurement: ");
                string systemTo = Console.ReadLine();
                Console.WriteLine("Enter the value to convert: ");
                string value = Console.ReadLine();

                Converter webServiceConverter = new Converter();
                Console.WriteLine("\n{0} {1} = {2} {3}",value, systemFrom,webServiceConverter.Conveter(systemFrom, systemTo, value),systemTo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
