using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPShop.Services
{
    public class EmailMessageSender : IMessageSender
    {
        public string Send(string message)
        {
            return message;
        }
    }
}
