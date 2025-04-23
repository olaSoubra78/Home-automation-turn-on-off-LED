using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EspTest3.Models;
//using EspTest3.Models;

//using Action = EspTest3.Models.Action;


namespace EspTest3.Bl
{
    public interface IAction
    {
        public List<TblAction> GetActionList();

    }
    public class ClsAction : IAction
    {
        DbAb2616EsptestContext ctx;
        public ClsAction(DbAb2616EsptestContext ctx)
        {
            this.ctx = ctx;
        }
        public List<TblAction> GetActionList()
        {
            try
            {
                List<TblAction> myList = ctx.TblActions.ToList();
                return myList;
            }
            catch (Exception e)
            {
                var g = e.Message;
                return new List<TblAction>();

            }
        }

    }

}
