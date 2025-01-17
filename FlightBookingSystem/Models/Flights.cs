//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>/* Copyright 2019, "All Rights Reserved" Haoran Zhang*/
//------------------------------------------------------------------------------

namespace FlightBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Flights
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Flights()
        {
            this.Bookings = new HashSet<Bookings>();
            this.Comments = new HashSet<Comments>();
        }
    
        public int Id { get; set; }
        [RegularExpression(@"^[A-Z a-z]+$", ErrorMessage = "Please enter a departure,Numbers are not allowed")]
        public string departure { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> departureDate { get; set; }
        [RegularExpression(@"^[A-Z a-z]+$", ErrorMessage = "Please enter a destiantion,Numbers are not allowed")]
        public string destination { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<DateTime> arrivalDate { get; set; }
        public string flightNumber { get; set; }
        [Column(TypeName = "numeric")]
        public Nullable<int> totalSeats { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bookings> Bookings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comments> Comments { get; set; }
    }
}
