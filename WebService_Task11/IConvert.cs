namespace WebServiceTask
{
    /// <summary>
    /// This interface contains method for converting data, which should be implemented 
    /// </summary>
    public interface IConvert
    {
        double ConvertTo(string systemFrom, string systemTo, string value);
    }
}
