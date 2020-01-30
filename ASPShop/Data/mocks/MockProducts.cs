using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPShop.Data.interfaces;
using ASPShop.Data.Models;

namespace ASPShop.Data.mocks
{
    public class MockProducts : IAllProducts
    {
        private readonly IProductsCategory _categoryProducts = new MockCategory();
        public IEnumerable<Product> Products
        {
            get
            {
                return new List<Product> {
                new Phone {
                    Name = "iPhone 11",
                    ShortDesk = "Новый Айфон - cтильний, ультра функціональний",
                    LongDesk = "Вага	194 г/nЄмність акумулятора 3 110 мАч/nКолір/nBlack/nОб'єм пам'яті   64 ГБ/nДіагональ екрану    6,1/nЕкран   Liquid Retina HD(1792x828)/nПроцесор    Apple A13 Bionic/nФронтальна камера   7 Мп/nОсновна камера  12Мп+12Мп/nМодуль Sim  1 Sim",
                    Img = "/wwwroot/img/IPhone11.png",
                    Price = 22000,
                    IsFavourite = true,
                    Availible = true,
                    Category = _categoryProducts.AllCategories.ElementAt(0)
                },
                new HeadPhone {Name = "AirPods Pro",
                    ShortDesk = "AirPods Pro – настав час почути ідеальний звук",
                    LongDesk = "Еще чище звук, еще меньше помех – новые Airpods Pro с активным шумоподавлением позволяют полностью погрузиться в звучание. Больше никаких посторонних шумов в транспорте, фоновых разговоров коллег по работе, ничто не помешает вам оставаться наедине с собеседником или любимый аудиотреком. При этом в любой момент можно активировать режим «прозрачности» для доступности окружающих звуков.",
                    Img = "/wwwroot/img/AirPodsPro.png",
                    Price = 7999,
                    IsFavourite = false,
                    Availible = true,
                    Category =  _categoryProducts.AllCategories.ElementAt(1)
                },
                new Watch {Name = "Apple Watch Series 5",
                    ShortDesk = "Стильний смарт-годинник",
                    LongDesk = "Apple Watch Series 5 GPS, 44mm Space Gray Aluminum Case with Black Sport Band (MWVF2)",
                    Img = "/wwwroot/img/AppleWatch.png",
                    Price = 11000,
                    IsFavourite = false,
                    Availible = true,
                    Category =  _categoryProducts.AllCategories.ElementAt(2)
                }
                };
            }
        }

        // public IEnumerable<Product> GetFavProducts { get; set; }

        public Product GetObjectProduct(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
