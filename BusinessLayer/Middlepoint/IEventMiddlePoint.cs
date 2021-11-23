using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using Microsoft.AspNetCore.Components;

namespace BusinessLayer.Middlepoint
{
    public interface IEventMiddlePoint
    {
        Task<EventList> eventFilter(Boolean byDate, Boolean byAvailability, int currentPage, int categoryId);
    }
}