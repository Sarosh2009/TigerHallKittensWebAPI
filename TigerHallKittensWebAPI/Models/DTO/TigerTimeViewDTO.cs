using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TigerHallKittensWebAPI.Models.DTO
{
    public class TigerTimeViewDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<System.DateTime> LastSeenTimeStamp { get; set; }
    }
}