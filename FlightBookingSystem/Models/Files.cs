/* Copyright 2019, "All Rights Reserved" Haoran Zhang*///------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FlightBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Files
    {
        public int Id { get; set; }
        public string path { get; set; }
        public string name { get; set; }
        public int BookingsId { get; set; }
    
        public virtual Bookings Booking { get; set; }
    }
}
