using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ASPShop.Data.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Display(Name="Ім'я та прізвище:")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина не менше 5 символів")]
        public string User { get; set; } // Ім'я Фамілія покупця
       
        [Display(Name = "Адреса:")]
        [StringLength(25)]
        [Required(ErrorMessage = "Довжина не менше 15 символів")]
        public string Address { get; set; } // Адрес покупця
        
        [Display(Name = "Номер телефону:")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Довжина не менше 10 символів")]
        public string ContactPhone { get; set; } // Контактний телефон покупця
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
