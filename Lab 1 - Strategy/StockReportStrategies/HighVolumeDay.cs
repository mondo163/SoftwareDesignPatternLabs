using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockReportStrategies
{
    public class HighVolumeDay : IFilterStrategy
    {
        public int maxVolume;

        public HighVolumeDay(int setMaxVolume = 20000000)
        {
            maxVolume = setMaxVolume;
        }

        public bool Include(TradingDay day)
        {
            return day.Volume > maxVolume;
        }
    }
}
