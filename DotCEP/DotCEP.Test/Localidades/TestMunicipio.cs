﻿using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DotCEP.Test
{
    [TestClass]
    public class TestMunicipio
    {
        [TestMethod]
        public void TestObtendoCodigoDoMunicipioUF()
        {
            int Resultado = DotCEP.Localidades.Municipio.ObterCodigoDoMunicipio("Pelotas", UF.RS);

            Assert.AreEqual(4314407, Resultado);
        }

        [TestMethod]
        public void TestObtendoCodigoDoMunicipioSiglaEstado()
        {
            int Resultado = DotCEP.Localidades.Municipio.ObterCodigoDoMunicipio("Pelotas", "RS");

            Assert.AreEqual(4314407, Resultado);
        }

        [TestMethod]
        public void TestObtendoCodigoDoMunicipioNomeEstado()
        {
            int Resultado = DotCEP.Localidades.Municipio.ObterCodigoDoMunicipio("Pelotas", "Rio Grande do Sul");

            Assert.AreEqual(4314407, Resultado);
        }


        [TestMethod]
        public void TestObtendoCodigoDoMunicipioCodigoEstado()
        {
            int Resultado = DotCEP.Localidades.Municipio.ObterCodigoDoMunicipio("Pelotas", 43);

            Assert.AreEqual(4314407, Resultado);
        }

        [TestMethod]
        public void TestObtendoInformacoesDoMunicipioCodigo()
        {
            Localidades.Municipio informacoesMunicipio = new Localidades.Municipio(4314407);

            Assert.AreEqual(4314407, informacoesMunicipio.Codigo);
            Assert.AreEqual(43, informacoesMunicipio.CodigoEstado);
            Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
        }


        [TestMethod]
        public void TestObtendoInformacoesDoMunicipioUF()
        {
            Localidades.Municipio informacoesMunicipio = new Localidades.Municipio("Pelotas", UF.RS);

            Assert.AreEqual(4314407, informacoesMunicipio.Codigo);
            Assert.AreEqual(43, informacoesMunicipio.CodigoEstado);
            Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
        }

        [TestMethod]
        public void TestObtendoInformacoesDoMunicipioSiglaEstado()
        {
            Localidades.Municipio informacoesMunicipio = new Localidades.Municipio("Pelotas", "RS");

            Assert.AreEqual(4314407, informacoesMunicipio.Codigo);
            Assert.AreEqual(43, informacoesMunicipio.CodigoEstado);
            Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
        }


        [TestMethod]
        public void TestObtendoInformacoesDoMunicipioNomeEstado()
        {
            Localidades.Municipio informacoesMunicipio = new Localidades.Municipio("Pelotas", "Rio Grande do Sul");

            Assert.AreEqual(4314407, informacoesMunicipio.Codigo);
            Assert.AreEqual(43, informacoesMunicipio.CodigoEstado);
            Assert.AreEqual("Pelotas", informacoesMunicipio.Nome);
        }


        [TestMethod]
        public void TestObtendoNomeDoMunicipio()
        {
            String Resultado = Localidades.Municipio.ObterNomeDoMunicipio(4314407);

            Assert.AreEqual("Pelotas", Resultado);
        }

        [TestMethod]
        public void TestListaDeTodosMunicipios()
        {
            int numeroDeTodosRegistros = Localidades.Municipio.ObterListaDeMunicipio().ToList().Count;
            Assert.AreEqual(5570, numeroDeTodosRegistros);
        }


        [TestMethod]
        public void TestListaDeMunicipiosPorUF()
        {
            int numeroDeTodosRegistrosDoRS = Localidades.Municipio.ObterListaDeMunicipio(UF.RS).ToList().Count;
            Assert.AreEqual(497, numeroDeTodosRegistrosDoRS);
        }

        [TestMethod]
        public void TestListaDeMunicipiosPorEstadoSigla()
        {
            int numeroDeTodosRegistrosDoRS = Localidades.Municipio.ObterListaDeMunicipio("SP").ToList().Count;
            Assert.AreEqual(645, numeroDeTodosRegistrosDoRS);
        }

        [TestMethod]
        public void TestListaDeMunicipiosPorEstado()
        {
            int numeroDeTodosRegistrosDoRS = Localidades.Municipio.ObterListaDeMunicipio("São Paulo").ToList().Count;
            Assert.AreEqual(645, numeroDeTodosRegistrosDoRS);
        }
    }
}