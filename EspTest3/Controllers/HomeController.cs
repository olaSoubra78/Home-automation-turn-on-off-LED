using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using EspTest3.Models;
using Microsoft.AspNetCore.Mvc;
using EspTest3.Bl;



namespace EspTest3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IActionDetails _actionDetails;
        private readonly INotyfService _notyf;
        private readonly ILED _led;

        public HomeController(ILogger<HomeController> logger,IActionDetails actionDetails,INotyfService notyf,ILED led)
        {
            _logger = logger;
            _actionDetails = actionDetails;
            _notyf = notyf;
            _led = led;
        }
        //First page
        public IActionResult Index()
        {

            return View();

        }

        //Page of last LEDS Status
        public IActionResult HistoryList()
        {
            List<DetailsViewModel> myList = new List<DetailsViewModel>();
            myList = _actionDetails.GetLastLedsStatus();
         
            return View(myList);
        }

        //On/OFF buttons Method
       // [System.Web.Http.HttpPost]
        [HttpPost]
        public async Task<IActionResult> Save(TblLedAction model)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    _notyf.Error("Something went wrong");

                }

                TblLedAction myAction = new TblLedAction();
                myAction.LedId = model.LedId;
                myAction.Time = DateTime.Now;
                myAction.ActionId = model.ActionId;

                var result = _actionDetails.Save(myAction);

                if (result)
                {
                    _notyf.Success("Done");
                }
                else
                {
                    _notyf.Error("Something went wrong");
                }



            }
            catch (Exception e)
            {

                var g = e.Message;
            }

            List<DetailsViewModel> myList = new List<DetailsViewModel>();
            myList = _actionDetails.GetLastLedsStatus();
            return View("HistoryList", myList);

        }
        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {

            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
