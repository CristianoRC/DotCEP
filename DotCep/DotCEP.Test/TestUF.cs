using NUnit.Framework;

namespace DotCEP.Test
{
	[TestFixture]
	public class TestUF
	{
		[Test]
		public void TestSiglaEstado()
		{
			Assert.AreEqual("RS", UF.RS.ToString());
		}

		[Test]
		public void TestCodigoEstado()
		{
			int codigoEstado = (int)UF.RS;

			Assert.AreEqual(43, codigoEstado);
		}
	}
}
