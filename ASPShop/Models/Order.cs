using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPShop.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string User { get; set; } // Ім'я Фамілія покупця
        public string Address { get; set; } // Адрес покупця
        public string ContactPhone { get; set; } // Контактний телефон покупця

        public int PhoneId { get; set; } // Ссилка на зв'язану можель Phone
        public Phone Phone { get; set; }
    }
}
