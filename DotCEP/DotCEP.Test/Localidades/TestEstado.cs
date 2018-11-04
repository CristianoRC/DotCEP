// using System;
// using System.Linq;
// using Microsoft.VisualStudio.TestTools.UnitTesting;

// namespace DotCEP.Test
// {
//     [TestClass]
//     public class TestEstado
//     {

//         [TestMethod]
//         public void TestObtendoCodigoDoEstadoAtravesDaSigla()
//         {
//             var Resultado = DotCEP.Localidades.Estado.ObterCodigoDoEstado("rs");

//             Assert.AreEqual(43, Resultado);
//         }

//         [TestMethod]
//         public void TestObtendoCodigoDoEstadoAtravesDoNome()
//         {
//             var Resultado = DotCEP.Localidades.Estado.ObterCodigoDoEstado("Rio Grande do Sul");

//             Assert.AreEqual(43, Resultado);
//         }

//         [TestMethod]
//         public void TestObtendoNomeDoEstadoAtravesDaSigla()
//         {
//             String Resultado = DotCEP.Localidades.Estado.ObterNomeDoEstado("RS");

//             Assert.AreEqual("Rio Grande do Sul", Resultado);
//         }


//         [TestMethod]
//         public void TestObtendoNomeDoEstadoAtravesDoID()
//         {
//             String Resultado = DotCEP.Localidades.Estado.ObterNomeDoEstado(43);

//             Assert.AreEqual("Rio Grande do Sul", Resultado);
//         }

//         [TestMethod]
//         public void TestObtendoSiglaDoEstadoAtravesDoID()
//         {
//             String Resultado = DotCEP.Localidades.Estado.ObterSiglaDoEstado(43);

//             Assert.AreEqual("RS", Resultado);
//         }

//         [TestMethod]
//         public void TestObtendoSiglaDoEstadoAtravesDoNome()
//         {
//             String Resultado = DotCEP.Localidades.Estado.ObterSiglaDoEstado("Rio Grande do Sul");

//             Assert.AreEqual("RS", Resultado);
//         }

//         [TestMethod]
//         public void TestListaDeEstados()
//         {
//             var listaEstados = DotCEP.Localidades.Estado.ObterListaDeEstados().ToList();

//             int NumeroDeResultados = listaEstados.Count;
//             DotCEP.Localidades.Estado EstadoNumeroZero = listaEstados[0];

//             Assert.AreEqual(12, EstadoNumeroZero.Codigo);
//             Assert.AreEqual("AC", EstadoNumeroZero.Sigla);
//             Assert.AreEqual("Acre", EstadoNumeroZero.Nome);
//             Assert.AreEqual(27, NumeroDeResultados);
//         }
//     }
// }
