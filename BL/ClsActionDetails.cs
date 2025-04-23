
using EspTest3.Models;
using Microsoft.EntityFrameworkCore;

namespace EspTest3.Bl
{
    public interface IActionDetails
    {
        public bool Save(TblLedAction newAction);
        public List<DetailsViewModel> GetAllDetails();
        public List<DetailsViewModel> GetLastLedsStatus();

    }
    public class ClsActionDetails : IActionDetails
    {
        DbAb2616EsptestContext ctx;
        public ClsActionDetails(DbAb2616EsptestContext ctx)
        {
            this.ctx = ctx;
        }
        public bool Save(TblLedAction newAction)// Add new action
        {
            try
            {

                newAction.Time = DateTime.UtcNow.AddHours(3);

                if (newAction.LedActionId == 0)
                {
                    ctx.TblLedActions.Add(newAction);


                }

                ctx.SaveChanges();
               
                return true;


            }
            catch (Exception e)
            {
                var g = e.Message;
                return false;
            }
        }
        public List<DetailsViewModel> GetAllDetails()
        {
            List<DetailsViewModel> detailsList = new List<DetailsViewModel>();
            var list = ctx.TblLedActions.ToList();   

            foreach (var item in list)
            {

                //var onOff = ctx.Actions?.FirstOrDefault(x => x.ActionId == item.ActionId);
                //var coulor = ctx.Leds?.FirstOrDefault(x => x.Ledid == item.Ledid);
                var detailsItem = new DetailsViewModel();

                detailsItem.ActionDes = ctx.TblActions?.FirstOrDefault(x => x.ActionId == item.ActionId).Description;
                detailsItem.LedColour = ctx.TblLeds?.FirstOrDefault(x => x.LedId == item.LedId).LedColour;
                detailsItem.Time = item.Time;

                detailsList.Add(detailsItem);

            }
            return detailsList;
        }
        public List<DetailsViewModel> GetLastLedsStatus()
        {
            var fullList = GetAllDetails();

            var latestStatusPerLed = fullList
            .GroupBy(d => d.LedColour.ToLower())
            .Select(g => g.OrderByDescending(d => d.Time).First())
            .ToList();

             List<DetailsViewModel> myList = new List<DetailsViewModel>();
            // Output result
            foreach (var detail in latestStatusPerLed)
            {
                
                //Console.WriteLine($"LED: {detail.LedColour}, Status: {detail.ActionDes}, Time: {detail.Time}");
                myList.Add(detail);
            }
           
            return myList;
        }

    }

}