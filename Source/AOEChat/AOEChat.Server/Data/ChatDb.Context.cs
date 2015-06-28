﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AOEChat.Server.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AOEChatEntities : DbContext
    {
        public AOEChatEntities()
            : base("name=AOEChatEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChatUser> ChatUsers { get; set; }
        public virtual DbSet<LastUserPosition> LastUserPositions { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    
        public virtual ObjectResult<GetGpsVectorFromTo_Result> GetGpsVectorFromTo(Nullable<double> latFrom, Nullable<double> lonFrom, Nullable<double> latTo, Nullable<double> lonTo)
        {
            var latFromParameter = latFrom.HasValue ?
                new ObjectParameter("latFrom", latFrom) :
                new ObjectParameter("latFrom", typeof(double));
    
            var lonFromParameter = lonFrom.HasValue ?
                new ObjectParameter("lonFrom", lonFrom) :
                new ObjectParameter("lonFrom", typeof(double));
    
            var latToParameter = latTo.HasValue ?
                new ObjectParameter("latTo", latTo) :
                new ObjectParameter("latTo", typeof(double));
    
            var lonToParameter = lonTo.HasValue ?
                new ObjectParameter("lonTo", lonTo) :
                new ObjectParameter("lonTo", typeof(double));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetGpsVectorFromTo_Result>("GetGpsVectorFromTo", latFromParameter, lonFromParameter, latToParameter, lonToParameter);
        }
    }
}