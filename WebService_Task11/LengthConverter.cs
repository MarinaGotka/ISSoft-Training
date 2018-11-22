using System;

namespace WebServiceTask
{
    /// <summary>
    /// This class for creating length converter, it contains method for working with entered data 
    /// </summary>
    public class LengthConverter : IConvert
    {
        double length;
        static LengthConverter instance;

        private LengthConverter()
        {
        }

        /// <summary>
        /// Method for prohibiting the creation of multiple instances
        /// </summary>
        public static LengthConverter GetInstance()
        {
            if (instance == null)
                instance = new LengthConverter();
            return instance;
        }

        /// <summary>
        /// Method to convert length from one measurement system to another
        /// </summary>
        /// <param name="systemFrom"></param>
        /// <param name="systemTo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double ConvertTo(string systemFrom, string systemTo, string value)
        {
            systemFrom = systemFrom.ToUpper();
            systemTo = systemTo.ToUpper();

            if (!(double.TryParse(value, out length) && ValidCheck(systemFrom, systemTo)))
            {
                throw new FormatException("Entered data is not valid");
            }
            else
            {
                if (systemFrom.Equals(ConverterTypeIdentifier.meterNotation) && systemTo.Equals(ConverterTypeIdentifier.footNotation))
                {
                    return MetersToFoots();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.meterNotation) && systemTo.Equals(ConverterTypeIdentifier.mileNotation))
                {
                    return MetersToMiles();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.footNotation) && systemTo.Equals(ConverterTypeIdentifier.meterNotation))
                {
                    return FootsToMeters();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.footNotation) && systemTo.Equals(ConverterTypeIdentifier.mileNotation))
                {
                    return FootsToMiles();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.mileNotation) && systemTo.Equals(ConverterTypeIdentifier.meterNotation))
                {
                    return MilesToMeters();
                }
                else
                {
                    return MetersToFoots();
                }
            }
        }

        /// <summary>
        /// Method to check valid of entered data
        /// </summary>
        /// <param name="systemFrom"></param>
        /// <param name="systemTo"></param>
        /// <returns></returns>
        private bool ValidCheck(string systemFrom, string systemTo)
        {
            if (!(ConverterTypeIdentifier.lengthNotations.Contains(systemFrom) && ConverterTypeIdentifier.lengthNotations.Contains(systemTo)))
            {
                throw new FormatException("Error!Wrong system notation.");
            }
            else
            {
                return length > 0;
            }
        }

        /// <summary>
        /// Method to convert length from meters to foots
        /// </summary>
        public double MetersToFoots()
        {
            return length * 3.281;
        }

        /// <summary>
        /// Method to convert length from foots to meters
        /// </summary>
        public double FootsToMeters()
        {
            return length / 3.281;
        }

        /// <summary>
        /// Method to convert length from meters to miles
        /// </summary>
        public double MetersToMiles()
        {
            return length / 1.609;
        }

        /// <summary>
        /// Method to convert length from miles to meters
        /// </summary>
        public double MilesToMeters()
        {
            return length * 1.609;
        }

        /// <summary>
        /// Method to convert length from foots to miles
        /// </summary>
        public double FootsToMiles()
        {
            return length / 5.28;
        }

        /// <summary>
        /// Method to convert length from miles to foots
        /// </summary>
        public double MilesToFoots()
        {
            return length * 5.28;
        }
    }
}