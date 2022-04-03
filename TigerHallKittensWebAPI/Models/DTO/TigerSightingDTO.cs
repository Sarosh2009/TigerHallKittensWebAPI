using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TigerHallKittensWebAPI.Models.DTO
{
    public class TigerSightingDTO
    {
        //public int Id { get; set; }
        public Nullable<int> TigerId { get; set; }
        public Nullable<double> Longitude { get; set; }
        public Nullable<double> Latitude { get; set; }
        public Nullable<System.DateTime> LastSeenTimeStamp { get; set; }

    }
}