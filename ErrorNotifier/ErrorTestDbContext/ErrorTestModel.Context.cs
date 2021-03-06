﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ErrorTestDbContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ErrorTestEntities : DbContext
    {
        public ErrorTestEntities()
            : base("name=ErrorTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Error> Errors { get; set; }
    
        public virtual int InsertError(string name, string description, Nullable<System.DateTime> createdTime)
        {
            var nameParameter = name != null ?
                new ObjectParameter("Name", name) :
                new ObjectParameter("Name", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var createdTimeParameter = createdTime.HasValue ?
                new ObjectParameter("CreatedTime", createdTime) :
                new ObjectParameter("CreatedTime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InsertError", nameParameter, descriptionParameter, createdTimeParameter);
        }
    
        public virtual ObjectResult<Error> GetError_ById(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Error>("GetError_ById", idParameter);
        }
    
        public virtual ObjectResult<Error> GetError_ById(Nullable<int> id, MergeOption mergeOption)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Error>("GetError_ById", mergeOption, idParameter);
        }
    
        public virtual ObjectResult<Error> ListErrors(Nullable<int> fromId, Nullable<int> toId)
        {
            var fromIdParameter = fromId.HasValue ?
                new ObjectParameter("fromId", fromId) :
                new ObjectParameter("fromId", typeof(int));
    
            var toIdParameter = toId.HasValue ?
                new ObjectParameter("toId", toId) :
                new ObjectParameter("toId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Error>("ListErrors", fromIdParameter, toIdParameter);
        }
    
        public virtual ObjectResult<Error> ListErrors(Nullable<int> fromId, Nullable<int> toId, MergeOption mergeOption)
        {
            var fromIdParameter = fromId.HasValue ?
                new ObjectParameter("fromId", fromId) :
                new ObjectParameter("fromId", typeof(int));
    
            var toIdParameter = toId.HasValue ?
                new ObjectParameter("toId", toId) :
                new ObjectParameter("toId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Error>("ListErrors", mergeOption, fromIdParameter, toIdParameter);
        }
    }
}
