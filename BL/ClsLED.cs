using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspTest3.Models;

namespace EspTest3.Bl
{
    public interface ILED
    {
        public List<TblLed> GetLEDList();

    }
    public class ClsLED : ILED
    {
        DbAb2616EsptestContext ctx;
        public ClsLED(DbAb2616EsptestContext ctx)
        {
            this.ctx = ctx;
        }
        public List<TblLed> GetLEDList()// GetLedList
        {
            try
            {
                List<TblLed> myList = ctx.TblLeds.ToList();
                return myList;
            }
            catch (Exception e)
            {
                var g = e.Message;
                return new List<TblLed>();
                
            }
        }

    }

}
