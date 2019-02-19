using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Common
{
    public class MyDateTime : IMyDateTime
    {
        public DateTime Now { get; set; }
        public MyDateTime()
        {
            Now = DateTime.Now;
        }
        public DateTime GetTime()
        {
            return Now;
        }
    }
}
