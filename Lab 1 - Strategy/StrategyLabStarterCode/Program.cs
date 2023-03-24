/************************************************
 * Starter code distributed for the Decorator lab
 * Created by Jeremy Ing - OIT Instructor
 ************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using StockReportStrategies;

namespace StrategyLabStarterCode
{
    class Program
    {
        private static void ReportTradingDays(StockMarket tradingDays, IFilterStrategy strategy)
        {
            foreach (TradingDay day in tradingDays.GetTradingDays())
            {
                //logic before the "if" inside the "foreach"
                if (strategy.Include(day))
                {
                    Console.WriteLine(day.ToString());
                }
            }
        }

        static void Main(string[] args)
        {
            IParsingStrategy original = new OriginalCSVParser();
            StockMarket tradingDays = new StockMarket(@"..\..\stockData.csv", original);

            IFilterStrategy highSwing = new HighDailySwing();
            ReportTradingDays(tradingDays, highSwing);

            IFilterStrategy highVolume = new HighVolumeDay();
            ReportTradingDays(tradingDays, highVolume);

            Console.WriteLine("\t\t\t--------- GOOG FILE ---------");

            //GOOG file strategy implementation.
            IParsingStrategy yahoo = new YahooCSVParser();
            StockMarket tradingDays2 = new StockMarket(@"..\..\GOOG.csv", yahoo);

            double maxPercent = .01;
            IFilterStrategy highSwing2 = new HighDailySwing(maxPercent);
            ReportTradingDays(tradingDays2, highSwing2);

            int maxVolume = 1000000;
            IFilterStrategy highVolume2 = new HighVolumeDay(maxVolume);
            ReportTradingDays(tradingDays2, highVolume2);

            //Prevent the console window from closing during debugging. 
            Console.ReadLine();
        }        
    }
}
