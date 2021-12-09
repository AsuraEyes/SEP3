using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Models;

namespace BusinessTier.MiddlePoint.EventMiddlePoints.Events
{
    public interface IEventMiddlePoint
    {
        Task<EventList> EventFilterAsync(FilterRest filterRest);
    }
}