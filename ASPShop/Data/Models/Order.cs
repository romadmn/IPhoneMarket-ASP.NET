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
        public string User { get; set; }
       
        [Display(Name = "Адреса:")]
        [StringLength(25)]
        public string Address { get; set; } 
        
        [Display(Name = "Ім'я власника карти:")]
        [StringLength(20)]
        public string CardName { get; set; } 
        [Display(Name = "Номер карти:")]
        [StringLength(20)]
        [DataType(DataType.CreditCard)]
        public string CardNumber { get; set; } 
        [Display(Name = "Дата карти:")]
        [StringLength(20)]
        public string CardDate { get; set; } 
        [Display(Name = "CVV код:")]
        [StringLength(3)]
        [Required(ErrorMessage = "Довжина 3 симоли!")]
        public string CardCvv { get; set; } 
        [Display(Name = "Номер телефону:")]
        [StringLength(20)]
        [DataType(DataType.PhoneNumber)]
        public string ContactPhone { get; set; } 
        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }
        public List<OrderDetail> OrderDetail { get; set; }
    }
}
