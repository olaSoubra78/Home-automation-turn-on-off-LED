using EspTest3.Bl;
using EspTest3.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EspTest2.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LedController : ControllerBase
    {
        private readonly ILED led;

        public LedController(ILED _led)
        {
            led = _led;
        }


        // GET: api/<LedController>
        [HttpGet]
        public List<TblLed> Get()
        {
            List<TblLed> myList = new List<TblLed>();
            myList = led.GetLEDList().ToList();
            return myList;
        }

       


        // GET api/<LedController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LedController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LedController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LedController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
