using System;

namespace CoffeeShop.Infrastructyre
{
    public class Espresso : Coffee
    {
        public Espresso()
        {
            Name = "Эспрессо";
        }

        public override void Grind() => Console.WriteLine("Перемалываем зерна для эспрессо");
        public override void Brew() => Console.WriteLine("Готовим эспрессо под давлением");
        public override void Serve() => Console.WriteLine("Подаем эспрессо в маленькой чашке");
    }
}
