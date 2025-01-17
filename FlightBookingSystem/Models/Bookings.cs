//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
/* Copyright 2019, "All Rights Reserved" Haoran Zhang*/
namespace FlightBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Bookings
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Bookings()
        {
            this.Images = new HashSet<Files>();
        }
    
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z a-z]+$", ErrorMessage = "Numbers are not allowed")]
        public string name { get; set; }
        public string email { get; set; }
        [Column(TypeName = "numeric")]
        public Nullable<int> seats { get; set; }
        [RegularExpression(@"^[A-Z a-z]+$", ErrorMessage = "Numbers are not allowed")]
        public string status { get; set; }
        [Column(TypeName = "numeric")]
        public Nullable<int> price { get; set; }
        [Column(TypeName = "numeric")]
        public Nullable<int> rating { get; set; }
        public int FlightsId { get; set; }
    
        public virtual Flights Flight { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Files> Images { get; set; }
    }
}
