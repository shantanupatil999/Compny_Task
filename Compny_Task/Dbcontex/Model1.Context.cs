//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Compny_Task.Dbcontex
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PracticalTestEntities : DbContext
    {
        public PracticalTestEntities()
            : base("name=PracticalTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Emp_Table> Emp_Table { get; set; }
    
        public virtual ObjectResult<sp_Table_Result> sp_Table()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_Table_Result>("sp_Table");
        }
    }
}
