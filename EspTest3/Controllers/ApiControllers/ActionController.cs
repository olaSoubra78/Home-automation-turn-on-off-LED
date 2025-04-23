using EspTest3.Bl;
using EspTest3.Models;
using Microsoft.AspNetCore.Mvc;
using Action = EspTest3.Models.TblAction;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EspTest2.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {

        private readonly IAction action;

        public ActionController(IAction _action)
        {
            action = _action;
        }

        // GET: api/<ActionController>
        [HttpGet]
        public List<TblAction> Get()
        {
            List<TblAction> myList = new List<TblAction>();
            myList = action.GetActionList();
            return myList;
        }

        // GET api/<ActionController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ActionController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ActionController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ActionController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
