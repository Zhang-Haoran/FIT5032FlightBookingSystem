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
    
    public partial class Comments
    {
        public int Id { get; set; }
        public string content { get; set; }
        public Nullable<int> rating { get; set; }
        public int FlightsId { get; set; }
    
        public virtual Flights Flight { get; set; }
    }
}
