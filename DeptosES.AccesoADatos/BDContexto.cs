﻿using DeptosES.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeptosES.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Municipio> Municipio { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=JC-PC;Initial Catalog=ProyectoEjemplo;Integrated Security=True; encrypt = false; trustServerCertificate = false");
            //optionsBuilder.UseSqlServer(@"Data Source=deptosDB.mssql.somee.com; Initial Catalog=deptosDB; User Id=deptosProject; Pwd=admin2022");
        }
    }
}
