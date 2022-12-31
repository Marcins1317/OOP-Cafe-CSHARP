using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieObiektoweZadanie
{
    internal class UserMenu
    {
        public static readonly UserMenu returnMenu = new UserMenu("Powrót");
        private readonly String name;
        private readonly UserMenuExecuter executer;
        private readonly UserMenu[] submenu;
        private readonly Context context;
        private UserMenu(String name, UserMenuExecuter executer, UserMenu[] submenu, Context context)
        {
            this.name = name;
            this.executer = executer;
            this.submenu = submenu;
            this.context = context;
        }
        public UserMenu(String name, UserMenuExecuter executer, Context context = null) : this(name, executer, null, context) { }
        public UserMenu(String name, UserMenu[] submenu, Context context = null) : this(name, null, submenu, context) { }
        public UserMenu(String name) : this(name, null, null, null) { }
        public static void Run(String title, UserMenu[] submenu, Context context = null)
        {
            while (true)
            {
                Console.WriteLine($"* {title}:");
                for (int i = 0; i < submenu.Length; ++i) Console.WriteLine($"{i + 1}. {submenu[i].name}");
                Console.Write("Wybierz opcję: ");
                if (!int.TryParse(Console.ReadLine(), out int pos)) pos = -1;
                if ((1 <= pos) && (pos <= submenu.Length))
                {
                    UserMenu sub = submenu[pos - 1];
                    string subtitle = $"{title} * {sub.name}";
                    Context subcontext = context.combine(sub.context);
                    if (sub.submenu != null)
                    {
                        Run(subtitle, sub.submenu, subcontext);
                    }
                    else if (sub.executer != null)
                    {
                        if (!sub.executer(subtitle, subcontext)) break;
                    }
                    else break;
                }
                else Console.WriteLine("Nie ma takiej opcji");
                Console.WriteLine();
            }
        }
    }
}
