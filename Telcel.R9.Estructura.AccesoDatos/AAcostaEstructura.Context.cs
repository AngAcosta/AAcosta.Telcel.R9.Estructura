﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Telcel.R9.Estructura.AccesoDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class AAcostaEstructuraEntities : DbContext
    {
        public AAcostaEstructuraEntities()
            : base("name=AAcostaEstructuraEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Departamento> Departamentoes { get; set; }
        public virtual DbSet<Empleado> Empleadoes { get; set; }
        public virtual DbSet<Puesto> Puestoes { get; set; }
        public virtual DbSet<EmpleadoView> EmpleadoViews { get; set; }
    
        public virtual ObjectResult<DepartamentoGetAll_Result> DepartamentoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DepartamentoGetAll_Result>("DepartamentoGetAll");
        }
    
        public virtual int EmpleadoAdd(string nombre, Nullable<int> puestoID, Nullable<int> departamentoID)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var puestoIDParameter = puestoID.HasValue ?
                new ObjectParameter("PuestoID", puestoID) :
                new ObjectParameter("PuestoID", typeof(int));
    
            var departamentoIDParameter = departamentoID.HasValue ?
                new ObjectParameter("DepartamentoID", departamentoID) :
                new ObjectParameter("DepartamentoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoAdd", nombreParameter, puestoIDParameter, departamentoIDParameter);
        }
    
        public virtual int EmpleadoDelete(Nullable<int> empleadoID)
        {
            var empleadoIDParameter = empleadoID.HasValue ?
                new ObjectParameter("EmpleadoID", empleadoID) :
                new ObjectParameter("EmpleadoID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("EmpleadoDelete", empleadoIDParameter);
        }
    
        public virtual ObjectResult<EmpleadoGetAll_Result> EmpleadoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetAll_Result>("EmpleadoGetAll");
        }
    
        public virtual ObjectResult<PuestoGetAll_Result> PuestoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<PuestoGetAll_Result>("PuestoGetAll");
        }
    
        public virtual ObjectResult<EmpleadoGetNombre_Result> EmpleadoGetNombre(string nombre)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EmpleadoGetNombre_Result>("EmpleadoGetNombre", nombreParameter);
        }
    }
}
