using EspTest3.Bl;
using EspTest3.Models;
using Microsoft.AspNetCore.Mvc;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EspTest3.ApiControllers
{
    


    [Route("api/[controller]")]
    [ApiController]
    public class ActionDetailsController : ControllerBase
    {
        private readonly IActionDetails detail;
        

        public  ActionDetailsController(IActionDetails _detail)
        {
            detail = _detail;
        }

        // GET: api/<ActionDetailsController> => get List of all details history
        [HttpGet]
        public List<DetailsViewModel> Get()
        {
            List<DetailsViewModel> myList = new List<DetailsViewModel>();
            myList= detail.GetAllDetails();
            return myList;
        }

        // GET api/<ActionDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }


        // call it in postman by "http://nanouche-001-site1.mtempurl.com/api/ActionDetails"
        // here we put parameters in head so it is not save to put it in body see the method AddDetailsInBody()
        // POST api/<ActionDetailsController>
        [HttpPost]
        public bool Post([FromBody] TblLedAction input)
        {
            TblLedAction MyDetail = new TblLedAction
            {
                ActionId = input.ActionId,
                Time = DateTime.Now,
                LedId = input.LedId
            };

            var result = detail.Save(MyDetail);
            return result;
        }


        // call it in postman by "http://nanouche-001-site1.mtempurl.com/api/ActionDetails/AddDetails?Ledid=1&ActionId=1"
        [Route("AddDetails")] // same as post method up but we can call it by its name
        [HttpPost]
        public bool AddDetails( TblLedAction input)
        {

            TblLedAction MyDetail = new TblLedAction
            {
                ActionId = input.ActionId,
                Time = DateTime.UtcNow.AddHours(3),
                LedId = input.LedId
            };

            var result = detail.Save(MyDetail);
            return result;

        }


        // call it in postman by "http://nanouche-001-site1.mtempurl.com/api/ActionDetails/AddDetailsInBody" // send ledid and ActionId in body
        [HttpPost]
        [Route("AddDetailsInBody")] // same as post method up but we can call it by its name
        public List<DetailsViewModel> AddDetailsInBody([FromBody] TblLedAction input)
        {
            TblLedAction MyDetail = new TblLedAction
            {
                ActionId = input.ActionId,
                Time = DateTime.UtcNow,
                LedId = input.LedId,
                
            };

            var result = detail.Save(MyDetail);
            List<DetailsViewModel> myList = new List<DetailsViewModel>();

            if (result)
            {
                
                myList = detail.GetLastLedsStatus();
                
            }
           
                return myList;

        }



        [HttpGet]
        [Route("GetLostStatus")]
        public List<DetailsViewModel> GetLostStatus()
        {
            List<DetailsViewModel> myList = new List<DetailsViewModel>();
            myList = detail.GetLastLedsStatus().ToList();
            return myList;
        }

        // PUT api/<ActionDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActionDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
