//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RentalWebAppR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rental
    {
        public int RentalId { get; set; }
        public int RentalPrice { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int ApartmentId { get; set; }
        public int TenantUserID { get; set; }
        public int EmployeeUserID { get; set; }
    
        public virtual Apartment Apartment { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Tenant Tenant { get; set; }
    }
}