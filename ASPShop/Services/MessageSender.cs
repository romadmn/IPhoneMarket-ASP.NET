using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPShop.Services
{
    public class MessageSender
    {
        private IMessageSender _sender;
        public MessageSender(IMessageSender sender)
        {
            _sender = sender;
        }
        public string Send(string message)
        {
            return _sender.Send(message);
        }
    }
}
