using NUnit.Framework;

namespace DotCEP.Test
{
	[TestFixture]
	public class TestUF
	{
		[Test]
		public void TestSiglaEstado()
		{
			Assert.That(UF.RS.ToString(), Is.EqualTo("RS"));
		}

		[Test]
		public void TestCodigoEstado()
		{
			int codigoEstado = (int)UF.RS;

			Assert.That(codigoEstado, Is.EqualTo(43));
		}
	}
}
