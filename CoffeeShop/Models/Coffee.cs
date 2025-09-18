using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructyre
{
    public abstract class Coffee
    {
        public string Name { get; protected set; }

        public abstract void Grind();
        public abstract void Brew();
        public abstract void Serve();

        public void Prepare()
        {
            Grind();
            Brew();
            Serve();
        }
    }
}
