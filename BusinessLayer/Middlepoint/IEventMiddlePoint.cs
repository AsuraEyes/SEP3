using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessLayer.Models;
using Microsoft.AspNetCore.Components;

namespace BusinessLayer.Middlepoint
{
    public interface IEventMiddlePoint
    {
        Task<EventList> eventFilter(FilterREST filterRest);
    }
}