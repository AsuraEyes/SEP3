using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookAndPlaySOAP;
using BusinessTier.Models;
using Microsoft.AspNetCore.Components;

namespace BusinessTier.Middlepoint
{
    public interface IEventMiddlePoint
    {
        Task<EventList> EventFilterAsync(FilterREST filterRest);
    }
}