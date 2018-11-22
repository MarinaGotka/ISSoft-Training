using System;

namespace WebServiceTask
{
    /// <summary>
    /// This class for creating different types of converters
    /// </summary>
    static class Factory
    {
        /// <summary>
        /// Method to create needed type of converter
        /// </summary>
        /// <param name="systemFrom"></param>
        /// <returns></returns>
        public static IConvert Create(string systemFrom)
        {
            switch(ConverterTypeIdentifier.GetConverterType(systemFrom))
            {
                case Converters.Temperature:
                    return TemperatureConverter.GetInstance();
                case Converters.Volume:
                    return VolumeConverter.GetInstance();
                case Converters.Length:
                    return LengthConverter.GetInstance();
                default:
                    throw new Exception("Error!Wrong system notation.");
            }
        }
    }
}