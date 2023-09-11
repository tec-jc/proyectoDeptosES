﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DeptosES.AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeptosES.EntidadesDeNegocio;

namespace DeptosES.AccesoADatos.Tests
{
    [TestClass()]
    public class MunicipioDALTests
    {
        private static Municipio municipioInicial = new Municipio { Id = 2, IdDepartamento = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var municipio = new Municipio();
            municipio.IdDepartamento = municipioInicial.IdDepartamento;
            municipio.Nombre = "Acajutla";
            municipio.Descripcion = "Municipio famoso por el puerto que lleva su mismo nombre";
            municipio.Imagen = "https://www.presidencia.gob.sv/wp-content/uploads/2022/07/Promo-YouTube-YouTube-thumbnail-size-21-1024x576.jpeg";
            int result = await MunicipioDAL.CrearAsync(municipio);
            Assert.AreNotEqual(0, result);
            municipioInicial.Id = municipio.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var municipio = new Municipio();
            municipio.Id = municipioInicial.Id;
            municipio.IdDepartamento = municipioInicial.IdDepartamento;
            municipio.Nombre = "Ciudad de Acajutla";
            municipio.Descripcion = "Municipio famoso por el puerto que lleva su mismo nombre";
            municipio.Imagen = "https://www.presidencia.gob.sv/wp-content/uploads/2022/07/Promo-YouTube-YouTube-thumbnail-size-21-1024x576.jpeg";
            int result = await MunicipioDAL.ModificarAsync(municipio);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var municipio = new Municipio();
            municipio.Id = municipioInicial.Id;
            var resultMunicipio = await MunicipioDAL.ObtenerPorIdAsync(municipio);
            Assert.AreEqual(municipio.Id, resultMunicipio.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultMunicipios = await MunicipioDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultMunicipios.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var municipio = new Municipio();
            municipio.IdDepartamento = municipioInicial.IdDepartamento;
            municipio.Nombre = "A";
            municipio.Descripcion = "a";
            municipio.Top_Aux = 10;
            var resultMunicipios = await MunicipioDAL.BuscarAsync(municipio);
            Assert.AreNotEqual(0, resultMunicipios.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirDepartamentosAsyncTest()
        {
            var municipio = new Municipio();
            municipio.IdDepartamento = municipioInicial.IdDepartamento;
            municipio.Nombre = "A";
            municipio.Descripcion = "a";
            municipio.Top_Aux = 10;
            var resultMunicipios = await MunicipioDAL.BuscarIncluirDepartamentosAsync(municipio);
            Assert.AreNotEqual(0, resultMunicipios.Count);
            var ultimoMunicipio = resultMunicipios.FirstOrDefault();
            Assert.IsTrue(ultimoMunicipio.Departamento != null && municipio.IdDepartamento == ultimoMunicipio.Departamento.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var municipio = new Municipio();
            municipio.Id = municipioInicial.Id;
            int result = await MunicipioDAL.EliminarAsync(municipio);
            Assert.AreNotEqual(0, result);
        }
    }
}