/*********************************************
 * Starter Code for Decorater lab
 * Created By Jeremy ING - OIT Instructor
 *********************************************/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrdersDll;

namespace DecoratorLabStarterCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order();

            order.AddItem("SeahawksHats", 2, 1.5, 0.2);
            order.AddItem("SeahawksGloves", 1, 3.0, 0.5);
            order.AddItem("SeahawksSocks", 6, 1.9, 0.1);
            order.AddItem("SeahawksBanners", 3, 8.0, 1.5);
            order.AddItem("SeahawksFootBalls", 4, 5.6, 0.6);
            order.AddItem("SeahawksJerseys", 2, 2.3, 0.4);

            order.PrintOrderItems();

            Console.WriteLine("-------------------------------------------");

            AbstractOrderClass expressOrder = new ExpressDeliveryOrderDecorator(order);
            expressOrder.PrintOrderItems();

            Console.WriteLine("VISA---------------------------------------");

            AbstractOrderClass visaOrder = new VisaOrderDecorator(order);
            visaOrder.PrintOrderItems();

            Console.WriteLine("AmEx---------------------------------------");

            AbstractOrderClass amExOrder = new AmericanExpressOrderDecorator(order);
            amExOrder.PrintOrderItems();

            Console.WriteLine("Express + Visa-----------------------------");

            AbstractOrderClass expressVisaOrder = new ExpressDeliveryOrderDecorator(order);
            expressVisaOrder = new VisaOrderDecorator(expressVisaOrder);
            expressVisaOrder.PrintOrderItems();


            Console.ReadLine();
        }
    }
}
