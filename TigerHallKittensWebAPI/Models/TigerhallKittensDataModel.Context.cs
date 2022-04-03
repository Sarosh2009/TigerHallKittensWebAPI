﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbContextTigerhallKittens : DbContext , ITigerHallKittensContext
    {
        public dbContextTigerhallKittens()
            : base("name=dbContextTigerhallKittens")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
        public void MarkAsModified(Tiger item)
        {
            Entry(item).State = EntityState.Modified;
        }

        public virtual DbSet<Tiger> Tigers { get; set; }
        public virtual DbSet<TigerSighting> TigerSightings { get; set; }
    
        public virtual int CreateTiger(string name, Nullable<System.DateTime> dateOfBirth, Nullable<System.DateTime> lastSeenTimeStamp, Nullable<double> latitude, Nullable<double> longitude)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var dateOfBirthParameter = dateOfBirth.HasValue ?
                new ObjectParameter("DateOfBirth", dateOfBirth) :
                new ObjectParameter("DateOfBirth", typeof(System.DateTime));
    
            var lastSeenTimeStampParameter = lastSeenTimeStamp.HasValue ?
                new ObjectParameter("LastSeenTimeStamp", lastSeenTimeStamp) :
                new ObjectParameter("LastSeenTimeStamp", typeof(System.DateTime));
    
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("Latitude", latitude) :
                new ObjectParameter("Latitude", typeof(double));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("Longitude", longitude) :
                new ObjectParameter("Longitude", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateTiger", nameParameter, dateOfBirthParameter, lastSeenTimeStampParameter, latitudeParameter, longitudeParameter);
        }
    
        public virtual int CreateTigerSighting(Nullable<int> tigerId, Nullable<double> longitude, Nullable<double> latitude, Nullable<System.DateTime> lastSeenTimeStamp, string filePath)
        {
            var tigerIdParameter = tigerId.HasValue ?
                new ObjectParameter("TigerId", tigerId) :
                new ObjectParameter("TigerId", typeof(int));
    
            var longitudeParameter = longitude.HasValue ?
                new ObjectParameter("Longitude", longitude) :
                new ObjectParameter("Longitude", typeof(double));
    
            var latitudeParameter = latitude.HasValue ?
                new ObjectParameter("Latitude", latitude) :
                new ObjectParameter("Latitude", typeof(double));
    
            var lastSeenTimeStampParameter = lastSeenTimeStamp.HasValue ?
                new ObjectParameter("LastSeenTimeStamp", lastSeenTimeStamp) :
                new ObjectParameter("LastSeenTimeStamp", typeof(System.DateTime));
    
            var filePathParameter = filePath != null ?
                new ObjectParameter("FilePath", filePath) :
                new ObjectParameter("FilePath", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("CreateTigerSighting", tigerIdParameter, longitudeParameter, latitudeParameter, lastSeenTimeStampParameter, filePathParameter);
        }
    }
}
