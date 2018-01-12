﻿using microObjectPizzaShop.Library;
using MicroObjectPizzaShop.Library.Texts;

namespace microObjectPizzaShop.Pizzas.Toppers
{
    public abstract class Topping : ITopping
    {
        public static readonly ITopping Mushroom = new RegularTopping("Mushroom");
        public static readonly ITopping Mozzarella = new RegularTopping("Mozzarella");
        public static readonly ITopping Olive = new RegularTopping("Olive");
        public static readonly ITopping Pepperoni = new MeatTopping("Pepperoni");
        public static readonly ITopping Bacon = new MeatTopping("Bacon");
        public static readonly ITopping Ham = new MeatTopping("Ham");
        public static readonly ITopping RoastedGarlic = new PremiumTopping("Roasted Garlic");
        public static readonly ITopping SunDriedTomato = new PremiumTopping("Sun Dried Tomato");
        public static readonly ITopping FetaCheese = new PremiumTopping("Feta Cheese");

        private readonly string _name;

        protected Topping(string name) => _name = name;

        public Money Cost(Money pizzaCost) => pizzaCost % PercentCost();
        public IText Name() => new TextOf(_name);
        protected abstract double PercentCost();

        private class RegularTopping : Topping
        {
            public RegularTopping(string name) : base(name) { }
            protected override double PercentCost() => .1;
        }
        private class MeatTopping : Topping
        {
            public MeatTopping(string name) : base(name) { }
            protected override double PercentCost() => .15;
        }

        private class PremiumTopping : Topping
        {
            public PremiumTopping(string name) : base(name) { }

            protected override double PercentCost() => .32;
        }
    }
    public interface ITopping
    {
        Money Cost(Money pizzaCost);
        IText Name();
    }
}