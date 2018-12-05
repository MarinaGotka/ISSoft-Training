namespace WebServiceTask
{
    /// <summary>
    /// Class for concrete 
    /// </summary>
    public class ConverterCommand : ICommand
    {
        IConvert receiver;
        public string systemFrom;
        public string systemTo;
        public string value;

        public ConverterCommand(IConvert converter, string systemFrom, string systemTo, string value)
        {
            receiver = converter;
            this.systemFrom = systemFrom;
            this.systemTo = systemTo;
            this.value = value;
        }

        /// <summary>
        /// Method execute concrete command
        /// </summary>
        public string Execute()
        {
            return receiver.ConvertTo(systemFrom, systemTo, value).ToString();
        }
    }
}