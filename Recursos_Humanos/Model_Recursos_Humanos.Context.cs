﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Recursos_Humanos
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class Recursos_HumanosEntities : DbContext
{
    public Recursos_HumanosEntities()
        : base("name=Recursos_HumanosEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Cargos> Cargos { get; set; }

    public virtual DbSet<Departamentos> Departamentos { get; set; }

    public virtual DbSet<Empleados> Empleados { get; set; }

    public virtual DbSet<Licencias> Licencias { get; set; }

    public virtual DbSet<Nominas> Nominas { get; set; }

    public virtual DbSet<Permisos> Permisos { get; set; }

    public virtual DbSet<Salida_Empleados> Salida_Empleados { get; set; }

    public virtual DbSet<Vacaiones> Vacaiones { get; set; }

    public virtual DbSet<V_Cargos_Empleados> V_Cargos_Empleados { get; set; }

    public virtual DbSet<V_Departamentos_Empleados> V_Departamentos_Empleados { get; set; }

    public virtual DbSet<V_Empleados_Activos> V_Empleados_Activos { get; set; }

    public virtual DbSet<V_Empleados_Inactivos> V_Empleados_Inactivos { get; set; }

    public virtual DbSet<V_Nominas> V_Nominas { get; set; }

}

}
