using ProgramowanieObiektoweZadanie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace ProgramowanieObiektoweZadanie
{
    
    using ProgramowanieObiektoweZadanie;

    internal class Program
    { 
        static void Main()
        {
        

        UserMenu.Run("Menu główne", Cafe.mainMenu, new Context { cafe = new Cafe() });
        }
    }
}