﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace laba2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KiyamobL5Entities : DbContext
    {
        private static KiyamobL5Entities context;
        public KiyamobL5Entities()
            : base("name=KiyamobL5Entities")
        {
        }
        public static KiyamobL5Entities GetContext()
        {
            if(context == null)
                context = new KiyamobL5Entities();
            return context;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Employee> Employee { get; set; }
    }
}
