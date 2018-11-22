using System.Web.Services;

namespace WebServiceTask
{
    /// <summary>
    /// This class contains method to convert data from one measurement system to another
    /// </summary>
    [WebService(Namespace = "http://www.dataconverter.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Converter : WebService
    {
        public Converter()
        {
        }

        /// <summary>
        /// Method to convert data from one measurement system to another
        /// </summary>
        /// <param name="systemFrom"></param>
        /// <param name="systemTo"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [WebMethod()]
        public string Conveter(string systemFrom, string systemTo, string value)
        {
            IConvert converter = Factory.Create(systemFrom);
            return converter.ConvertTo(systemFrom, systemTo, value).ToString();
        }
    }
}