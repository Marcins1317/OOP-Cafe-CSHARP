using ProgramowanieObiektoweZadanie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProgramowanieObiektoweZadanie
{
    internal class Cafe
    {
        private static readonly UserMenu[] orderMenu = new UserMenu[]
        {
            new UserMenu("Pokaż zamówienie",Order.ShowOrder),
            new UserMenu("Dodaj danie",Dish.makeCategoryMenu(Order.AddDish)),
            new UserMenu("Usuń danie", Dish.makeCategoryMenu(Order.RemoveDish)),
            new UserMenu("Rozlicz",Cafe.CompleteOrder),
            UserMenu.returnMenu,
        };
        public static readonly UserMenu[] mainMenu = new UserMenu[]
        {
            new UserMenu("Nowe zamówienie",Cafe.MakeOrder),
            new UserMenu("Wybierz zamówienie",Cafe.ChoiseOrder),
            new UserMenu("Koniec programu"),
        };
        private readonly List<Order> orders = new List<Order>();
        public static bool MakeOrder(string title, Context context)
        {
            Console.WriteLine(title);
            Console.Write("Podaj id: ");
            string id = Console.ReadLine();
            string subtitle = $"{title} / zamówienie {id}";
            foreach (Order ord in context.cafe.orders)
            {
                if (ord.id == id)
                {
                    Console.WriteLine($"Znaleziono zamówienie {id}");
                    Console.WriteLine();
                    UserMenu.Run(subtitle, orderMenu, context.combine(ord));
                    return true;
                }
            }
            Console.WriteLine($"Utworzono zamówienie {id}");
            Console.WriteLine();
            Order order = new Order(id);
            context.cafe.orders.Add(order);
            UserMenu.Run(subtitle, orderMenu, context.combine(order));
            return true;
        }
        public static bool ChoiseOrder(string title, Context context)
        {
            UserMenu[] menu =
                context.cafe.orders
                .OrderBy(order => order.id)
                .Select(order => new UserMenu(order.id, orderMenu, context.combine(order)))
                .Append(UserMenu.returnMenu)
                .ToArray()
            ;
            UserMenu.Run(title, menu.ToArray(), context);
            return true;
        }
        public static bool CompleteOrder(string title, Context context)
        {
            Console.WriteLine(title);
            Order.ShowOrder($"Zamówienie {context.order.id}", context);
            context.cafe.orders.Remove(context.order);
            return false;
        }
        public static string ShowPrice(int price)
        {
            return string.Format("{0:###0.00}", price / 100.0);
        }
    }
}
