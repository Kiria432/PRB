using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructyre
{
    public static class CoffeeFactory
    {
        public static Coffee CreateCoffee(string coffeeType)
        {
            switch (coffeeType.ToLower())
            {
                case "latte":
                case "латте":
                    return new Latte();
                case "espresso":
                case "эспрессо":
                    return new Espresso();
                case "americano":
                case "американо":
                    return new Americano();
                case "cappuccino":
                case "капучино":
                    return new Cappuccino();
                default:
                    throw new ArgumentException("Неизвестный тип кофе");
            }
        }
    }
}
