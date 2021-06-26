using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Common;
using System.Threading;

namespace MyApp.Controllers
{

    public class MyService
    {
        private readonly ITimeService _timeService;

        public MyService(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public DateTime GetTime() => _timeService.GetTime();
    }

    public class MySecondService
    {

        private readonly MyRepository _repository;

        public MySecondService(MyRepository repository)
        {
            _repository = repository;
        }

        public DateTime GetTime() => _repository.GetTime();
    }

    public class MyRepository
    {
        private readonly ITimeService _timeService;

        public MyRepository(ITimeService timeService)
        {
            _timeService = timeService;
        }

        public DateTime GetTime() => _timeService.GetTime();
    }
    public class TestController : Controller
    {
        private readonly MyService _myService;
        private readonly MySecondService _mySecondService;

        public TestController(MyService myService, MySecondService mySecondService)
        {
            _myService = myService;
            _mySecondService = mySecondService;
        }

        [Route("api/test")]
        public IActionResult Index()
        {
            var results = new List<string>();
            results.Add($"MyService : {_myService.GetTime().Ticks}");
            Thread.Sleep(1000);
            results.Add($"MySecondSerice : {_mySecondService.GetTime().Ticks}");

            return Ok(results);
        }
    }
}
