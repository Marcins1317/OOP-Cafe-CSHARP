using ProgramowanieObiektoweZadanie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramowanieObiektoweZadanie
{
    internal class Context
    {
        public Cafe cafe { get; set; }
        public Order order { get; set; }
        public Dish dish { get; set; }
        public Context combine(Context extra)
        {
            return (extra == null) ? this : new Context
            {
                cafe = (extra.cafe ?? cafe),
                order = (extra.order ?? order),
                dish = (extra.dish ?? dish)
            };
        }
        public Context combine(Order order)
        {
            return new Context
            {
                cafe = cafe,
                order = (order ?? this.order),
                dish = dish
            };
        }
        public Context combine(Dish dish)
        {
            return new Context
            {
                cafe = cafe,
                order = order,
                dish = (dish ?? this.dish)
            };
        }
    }
}
