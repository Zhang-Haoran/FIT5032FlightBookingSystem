﻿/* Copyright 2019, "All Rights Reserved" Haoran Zhang*/using System.Web;
using System.Web.Mvc;

namespace FlightBookingSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
