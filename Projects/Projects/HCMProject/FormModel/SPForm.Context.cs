﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SPForm : DbContext
    {
        public SPForm()
            : base("name=SPForm")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
    
        public virtual int SP_JobOpportunity_Ins(Nullable<System.Guid> hCMId, string title, string condition, string place, string expireDate)
        {
            var hCMIdParameter = hCMId.HasValue ?
                new ObjectParameter("HCMId", hCMId) :
                new ObjectParameter("HCMId", typeof(System.Guid));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var conditionParameter = condition != null ?
                new ObjectParameter("Condition", condition) :
                new ObjectParameter("Condition", typeof(string));
    
            var placeParameter = place != null ?
                new ObjectParameter("Place", place) :
                new ObjectParameter("Place", typeof(string));
    
            var expireDateParameter = expireDate != null ?
                new ObjectParameter("ExpireDate", expireDate) :
                new ObjectParameter("ExpireDate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_JobOpportunity_Ins", hCMIdParameter, titleParameter, conditionParameter, placeParameter, expireDateParameter);
        }
    
        public virtual int SP_JobOpportunity_Del(Nullable<System.Guid> hCMId)
        {
            var hCMIdParameter = hCMId.HasValue ?
                new ObjectParameter("HCMId", hCMId) :
                new ObjectParameter("HCMId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SP_JobOpportunity_Del", hCMIdParameter);
        }
    }
}
