using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockReportStrategies
{
    public class HighDailySwing : IFilterStrategy
    {
        private double maxPercent;

        public HighDailySwing(double setMaxPercent = 0.1)
        {
            maxPercent = setMaxPercent;
        }
        public bool Include(TradingDay day)
        {
            double swing = day.Open - day.Close;
            double percentageSwing = Math.Abs(swing / day.Open);

            return percentageSwing > maxPercent;
        }
    }
}
