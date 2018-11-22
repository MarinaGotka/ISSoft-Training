using System;

namespace WebServiceTask
{
    /// <summary>
    /// This class for creating temperature converter, it contains method for working with entered data 
    /// </summary>
    public class TemperatureConverter : IConvert
    {
        const double absCelsiusNull = -273.15;
        const double absFahrenheitNull = -459.67;
        static TemperatureConverter instance;

        double temperature;

        private TemperatureConverter()
        {
        }

        /// <summary>
        /// Method for prohibiting the creation of multiple instances
        /// </summary>
        public static TemperatureConverter GetInstance()
        {
            if (instance == null)
                instance = new TemperatureConverter();
            return instance;
        }
       
        /// <summary>
        /// Method to convert temperature from one measurement system to another
        /// </summary>
        /// <param name="systemFrom"></param>
        /// <param name="systemTo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double ConvertTo(string systemFrom, string systemTo, string value)
        {
            systemFrom = systemFrom.ToUpper();
            systemTo = systemTo.ToUpper();

            if (!(double.TryParse(value, out temperature) && ValidCheck(systemFrom, systemTo)))
            {
                throw new FormatException("Entered data is not valid");
            }
            else
            {
                if (systemFrom.Equals(ConverterTypeIdentifier.celsiusNotation) && systemTo.Equals(ConverterTypeIdentifier.fahrenheitNotation))
                {
                    return CelsiusToFahrenheit();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.celsiusNotation) && systemTo.Equals(ConverterTypeIdentifier.kelvinNotation))
                {
                    return CelsiusToKelvin();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.kelvinNotation) && systemTo.Equals(ConverterTypeIdentifier.celsiusNotation))
                {
                    return KelvinToCelsius();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.kelvinNotation) && systemTo.Equals(ConverterTypeIdentifier.fahrenheitNotation))
                {
                    return KelvinToFahrenheit();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.fahrenheitNotation) && systemTo.Equals(ConverterTypeIdentifier.celsiusNotation))
                {
                    return FahrenheitToCelsius();
                }
                else
                {
                    return FahrenheitToKelvin();
                }
            }
        }

        /// <summary>
        /// Method to check valid of entered data
        /// </summary>
        /// <param name="systemFrom"></param>
        /// <param name="systemTo"></param>
        /// <returns></returns>
        bool ValidCheck(string systemFrom, string systemTo)
        {
            if (!(ConverterTypeIdentifier.temperatureNotations.Contains(systemFrom) && ConverterTypeIdentifier.temperatureNotations.Contains(systemTo)))
            {
                throw new FormatException("Error!Wrong system notation.");
            }
            else if (systemFrom.Equals(ConverterTypeIdentifier.celsiusNotation))
            {
                return temperature > absCelsiusNull;
            }
            else if (systemFrom.Equals(ConverterTypeIdentifier.kelvinNotation))
            {
                return temperature > 0;
            }
            else 
            {
                return temperature > absFahrenheitNull;
            }
        }

        /// <summary>
        /// Method to convert temperature from Celsius to Fahrenheit
        /// </summary>
        public double CelsiusToFahrenheit()
        {
            return (temperature * 1.8 + 32);
        }
        
        /// <summary>
        /// Method to convert temperature from Fahrenheit to Celsuis
        /// </summary>
        public double FahrenheitToCelsius()
        {
            return ((temperature - 32) / 1.8);
        }

        /// <summary>
        /// Method to convert temperature from Celsius to Kelvin
        /// </summary>
        public double CelsiusToKelvin()
        {
            return (temperature + 273.15);
        }

        /// <summary>
        /// Method to convert temperature from Kelvin to Celsius
        /// </summary>
        public double KelvinToCelsius()
        {
            return (temperature - 273.15);
        }

        /// <summary>
        /// Method to convert temperature from Kelvin to Fahrenheit
        /// </summary>
        public double KelvinToFahrenheit()
        {
            return (temperature * 1.8 - 459.67);
        }

        /// <summary>
        /// Method to convert temperature from Fahrenheit to Kelvin
        /// </summary>
        public double FahrenheitToKelvin()
        {
            return ((temperature + 459.67) / 1.8);
        }
    }
}