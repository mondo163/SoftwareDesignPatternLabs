using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDll
{
    public class VisaOrderDecorator : OrderDecorator
    {
        private const double VISA_COST = 2.00d;

        public VisaOrderDecorator(AbstractOrderClass order) : base(order)
        {
        }

        public override double GetTotalCost()
        {
            return base.GetTotalCost() + VISA_COST;
        }

        public override void PrintOrderItems()
        {
            Console.WriteLine("A Service Cost May Apply");
            base.PrintOrderItems();
            Console.WriteLine("Grand Total with a  Visa service charge {0:C}", GetTotalCost());
        }
    }
}
