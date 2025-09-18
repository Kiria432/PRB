using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructyre
{
    public class CoffeeShopService
    {
        public Coffee OrderCoffee(string coffeeType)
        {
            Coffee coffee = CoffeeFactory.CreateCoffee(coffeeType);
            coffee.Prepare();
            return coffee;
        }
    }
}
