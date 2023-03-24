using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDll
{
    public class AmericanExpressOrderDecorator : OrderDecorator
    {
        private const double AMEX_COST = 5.00d;
        public AmericanExpressOrderDecorator(AbstractOrderClass order) : base(order)
        {
        }

        public override double GetTotalCost()
        {
            return base.GetTotalCost() + AMEX_COST;
        }

        public override void PrintOrderItems()
        {
            Console.WriteLine("A Service Charge Cost May Apply");
            base.PrintOrderItems();
            Console.WriteLine("Grand Total with a AmEx service charge {0:C}", GetTotalCost());
        }
    }
}
