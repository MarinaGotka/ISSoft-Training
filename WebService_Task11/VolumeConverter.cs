using System;

namespace WebServiceTask
{
    /// <summary>
    /// This class for creating volume converter, it contains method for working with entered data 
    /// </summary>
    public class VolumeConverter : IConvert
    {
        const double absCelsiusNull = -273.15;
        const double absFahrenheitNull = -459.67;
        static VolumeConverter instance;

        double volume;

        private VolumeConverter()
        {
        }

        /// <summary>
        /// Method for prohibiting the creation of multiple instances
        /// </summary>
        public static VolumeConverter GetInstance()
        {
            if (instance == null)
                instance = new VolumeConverter();
            return instance;
        }

        /// <summary>
        /// Method to convert volume from one measurement system to another
        /// </summary>
        /// <param name="systemFrom"></param>
        /// <param name="systemTo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public double ConvertTo(string systemFrom, string systemTo, string value)
        {
            systemFrom = systemFrom.ToUpper();
            systemTo = systemTo.ToUpper();

            if (!(double.TryParse(value, out volume) && ValidCheck(systemFrom, systemTo)))
            {
                throw new FormatException("Entered data is not valid");
            }
            else
            {
                if (systemFrom.Equals(ConverterTypeIdentifier.literNotation) && systemTo.Equals(ConverterTypeIdentifier.gallonNotation))
                {
                    return LitersToGallon();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.literNotation) && systemTo.Equals(ConverterTypeIdentifier.pintaNotation))
                {
                    return LitersToPints();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.gallonNotation) && systemTo.Equals(ConverterTypeIdentifier.literNotation))
                {
                    return GallonToLiters();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.gallonNotation) && systemTo.Equals(ConverterTypeIdentifier.pintaNotation))
                {
                    return GallonToPints();
                }
                else if (systemFrom.Equals(ConverterTypeIdentifier.pintaNotation) && systemTo.Equals(ConverterTypeIdentifier.literNotation))
                {
                    return PintsToLiters();
                }
                else
                {
                    return PintsToGallon();
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
            if (!(ConverterTypeIdentifier.volumeNotations.Contains(systemFrom) && ConverterTypeIdentifier.volumeNotations.Contains(systemTo)))
            {
                throw new FormatException("Error!Wrong system notation.");
            }
            else
            {
                return volume > 0;
            }
        }

        /// <summary>
        /// Method to convert volume from Liters to Gallon
        /// </summary>
        public double LitersToGallon()
        {
            return volume * 0.264;
        }

        /// <summary>
        /// Method to convert volume from Gallon to Liters
        /// </summary>
        public double GallonToLiters()
        {
            return volume / 0.264;
        }

        /// <summary>
        /// Method to convert volume from Liters to Pints
        /// </summary>
        public double LitersToPints()
        {
            return volume * 2.113;
        }

        /// <summary>
        /// Method to convert volume from Pints to Liters
        /// </summary>
        public double PintsToLiters()
        {
            return volume / 2.113;
        }

        /// <summary>
        /// Method to convert volume from Gallon to Pints
        /// </summary>
        public double GallonToPints()
        {
            return volume * 8;
        }

        /// <summary>
        /// Method to convert volume from Pints to Gallon
        /// </summary>
        public double PintsToGallon()
        {
            return volume / 8;
        }
    }
}