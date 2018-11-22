using System;
using System.Collections.Generic;

namespace WebServiceTask
{
    /// <summary>
    /// Class contains method to identify type of converter for creation
    /// </summary>
    static class ConverterTypeIdentifier
    {
        public const string celsiusNotation = "C";
        public const string kelvinNotation = "K";
        public const string fahrenheitNotation = "F";
        public static List<string> temperatureNotations = new List<string>() { celsiusNotation, kelvinNotation, fahrenheitNotation };

        public const string literNotation = "L";
        public const string gallonNotation = "GAL";
        public const string pintaNotation = "PT";
        public static List<string> volumeNotations = new List<string>() { literNotation, gallonNotation, pintaNotation };

        public const string meterNotation = "M";
        public const string mileNotation = "MI";
        public const string footNotation = "FT";
        public static List<string> lengthNotations = new List<string>() { meterNotation, mileNotation,footNotation };

        /// <summary>
        /// Method to identify type of converter for creation
        /// </summary>
        /// <param name="systemFrom"></param>
        /// <returns></returns>
        public static Converters GetConverterType(string systemFrom)
        {
            systemFrom = systemFrom.ToUpper();

            if (temperatureNotations.Contains(systemFrom))
            {
                return Converters.Temperature;
            }
            else if (volumeNotations.Contains(systemFrom))
            {
                return Converters.Volume;
            }
            else if (lengthNotations.Contains(systemFrom))
            {
                return Converters.Length;
            }
            else
            {
                throw new Exception("Error!Wrong system notation.");
            }
        }
    }
}