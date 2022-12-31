using ProgramowanieObiektoweZadanie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieObiektoweZadanie
{
    internal class Order
    {
        private readonly List<Dish> dishes = new List<Dish>();
        public string id { get; private set; }
        public Order(string id) { this.id = id; }
        public static bool AddDish(string Title, Context context)
        {
            Console.WriteLine(Title);
            context.order.dishes.Add(context.dish);
            Console.WriteLine($"Do zamówienia {context.order.id} dodano danie {context.dish.category}:{context.dish.title} - {Cafe.ShowPrice(context.dish.price)}");
            return true;
        }
        public static bool RemoveDish(string Title, Context context)
        {
            Console.WriteLine(Title);
            context.order.dishes.Remove(context.dish);
            Console.WriteLine($"Z zamówienia {context.order.id} usunięto danie {context.dish.category}:{context.dish.title} - {Cafe.ShowPrice(context.dish.price)}");
            return true;
        }

        public static bool ShowOrder(string title, Context context)
        {
            Console.Clear();
            Console.WriteLine(title);
            if (context.order.dishes.Count <= 0) Console.WriteLine("Zamówienie puste");
            else
            {
                foreach (Dish dish in context.order.dishes)
                {
                    Console.WriteLine(dish.Show());
                }
                Console.WriteLine($"razem: {Cafe.ShowPrice(context.order.Sum()).Trim()}");
            }
            return true;
        }
        public int Sum()
        {
            return
                dishes
                .Aggregate(0, (curr, dish) => (curr + dish.price))
            ;
        }
    }
}
