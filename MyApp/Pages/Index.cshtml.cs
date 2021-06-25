using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyApp.Common;

namespace MyApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ITimeService _time;

        public IndexModel(ITimeService time)
        {
            _time = time;

        }

        public DateTime NowTime { get; set; }
        public void OnGet()
        {
            NowTime = _time.GetTime();
        }
    }
}