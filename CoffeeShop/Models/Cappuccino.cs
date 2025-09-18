using System;

namespace CoffeeShop.Infrastructyre
{
    public class Cappuccino : Coffee
    {
        public Cappuccino()
        {
            Name = "Капучино";
        }
        public override void Grind() => Console.WriteLine("Перемалываем зерна для капучино");
        public override void Brew() => Console.WriteLine("Готовим эспрессо с молочной пенкой");
        public override void Serve() => Console.WriteLine("Подаем капучино в керамической чашке");
    }
}
