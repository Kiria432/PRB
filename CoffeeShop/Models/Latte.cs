using System;

namespace CoffeeShop.Infrastructyre
{
    public class Latte : Coffee
    {
        public Latte()
        {
            Name = "Латте";
        }

        public override void Grind() => Console.WriteLine("Перемалываем зерна для латте");
        public override void Brew() => Console.WriteLine("Готовим эспрессо и добавляем молоко");
        public override void Serve() => Console.WriteLine("Подаем латте в высокой чашке");
    }
}
