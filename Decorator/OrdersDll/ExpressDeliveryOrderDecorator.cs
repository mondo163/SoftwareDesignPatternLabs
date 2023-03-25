using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersDll
{
    public class ExpressDeliveryOrderDecorator : OrderDecorator
    {
        private const double SHIPPING_COST = 4.00d;
        public ExpressDeliveryOrderDecorator(AbstractOrderClass order)
            : base(order) { }

        public override double GetTotalCost()
        {
            return base.GetTotalCost() + SHIPPING_COST;
        }

        public override void PrintOrderItems()
        {
            Console.WriteLine("A Shipping Cost May Apply");
            base.PrintOrderItems();
            Console.WriteLine("Grand Total with shipping {0:C}", GetTotalCost());
        }
    }
}
