using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public class TimeService : ITimeService
    {
        public DateTime Now { get; set; }
        public TimeService()
        {
            Now = DateTime.Now;
        }
        public DateTime GetTime()
        {
            return Now;
        }
    }
}
