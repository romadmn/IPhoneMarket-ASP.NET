using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPShop.Services
{
    public interface IMessageSender
    {
        string Send(string message);
    }
}
