using System;

namespace CoffeeShop.Infrastructyre
{
    public class Americano : Coffee
    {
        public Americano()
        {
            Name = "Американо";
        }

        public override void Grind() => Console.WriteLine("Перемалываем зерна для американо");
        public override void Brew() => Console.WriteLine("Готовим эспрессо с водой");
        public override void Serve() => Console.WriteLine("Подаем американо в большой чашке");
    }
}
