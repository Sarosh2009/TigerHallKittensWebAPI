//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TigerHallKittensWebAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TigerSighting
    {
        public int Id { get; set; }
        public Nullable<int> TigerId { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<System.DateTime> LastSeenTimeStamp { get; set; }
    
        public virtual Tiger Tiger { get; set; }
    }
}
