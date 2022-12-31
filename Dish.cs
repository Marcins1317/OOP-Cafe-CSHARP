using ProgramowanieObiektoweZadanie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieObiektoweZadanie
{
    internal class Dish
    {
        private static readonly List<Dish> dishes = new List<Dish>()
        {
            new Dish("Przystawki","Pajda",999),
            new Dish("Przystawki","Koreczki",1199),
            new Dish("Zupy","Ogórkowa",2399),
            new Dish("Zupy","Pomidorowa",2199),
            new Dish("Dania główne","Schabowy",3499),
            new Dish("Dania główne","Pierogi",1799),
        };
        public static UserMenu[] makeCategoryMenu(UserMenuExecuter executer)
        {
            return
                dishes
                .Select(dish => dish.category)
                .Distinct()
                .OrderBy(category => category)
                .Select(category => new UserMenu(category, makeDishMenu(category, executer)))
                .Append(UserMenu.returnMenu)
                .ToArray()
            ;
        }
        private static UserMenu[] makeDishMenu(string category, UserMenuExecuter executer)
        {
            return
                dishes
                .Where(dish => (dish.category == category))
                .OrderBy(dish => dish.title)
                .Select(dish => new UserMenu(dish.title, executer, new Context { dish = dish }))
                .Append(UserMenu.returnMenu)
                .ToArray()
            ;
        }
        public string category { get; set; }
        public string title { get; set; }
        public int price { get; set; }
        private Dish(string category, string title, int price)
        {
            this.category = category;
            this.title = title;
            this.price = price;
        }
        public string Show()
        {
            return $"{Cafe.ShowPrice(price)} \t{category}:{title}";
        }
    }
    

    internal delegate bool UserMenuExecuter(string title, Context context);
}
