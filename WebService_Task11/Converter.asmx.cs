﻿using System.Collections.Generic;
using System.Text;
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
        public delegate string Result();
        public event Result EventSendCommand;

        List<ICommand> commandList = new List<ICommand>();

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
        public bool Conveter(string systemFrom, string systemTo, string value)
        {
            if (EventSendCommand == null)
            {
                IConvert converter = Factory.Create(systemFrom);
                ConverterCommand command = new ConverterCommand(converter, systemFrom, systemTo, value);
                commandList.Add(command);
            }
            else
            {
                EventSendCommand();
            }

            return true;

        }

        /// <summary>
        /// Method to show results of command list
        /// </summary>
        /// <returns></returns>
        [WebMethod()]
        public string ShowResults()
        {
            EventSendCommand += ShowResults;
            
            StringBuilder results = new StringBuilder().Clear();

            foreach (ConverterCommand command in commandList)
            {
                results.Append(command.value + " " + command.systemFrom + " = " + command.Execute() + " " + command.systemTo + "\n");
            }

            commandList.Clear();
            return results.ToString();
        }
    }
}