using System.Collections.Generic;

namespace DotCEP.Localidades
{
    public class Estado
    {
        private readonly IEstadoRepositorio _estadoRepositorio;

        private Estado()
        {
            _estadoRepositorio = new EstadoRepositorio();
        }

        public Estado(string siglaOuNome) : this()
        {
            if (siglaOuNome.Trim().Length == 2) siglaOuNome = siglaOuNome.Trim().ToUpper();


            var estadoTemp = _estadoRepositorio.ObterPorSiglaOuNome(siglaOuNome);

            Codigo = estadoTemp.Codigo;
            Nome = estadoTemp.Nome;
            Sigla = estadoTemp.Sigla;
        }

        public Estado(sbyte codigo) : this()
        {
            var estadoDoRepositorio = _estadoRepositorio.ObterPorCodigo(codigo);

            Codigo = estadoDoRepositorio.Codigo;
            Nome = estadoDoRepositorio.Nome;
            Sigla = estadoDoRepositorio.Sigla;
        }

        public sbyte Codigo { get; }

        public string Sigla { get; }

        public string Nome { get; }


        public static IEnumerable<Estado> ObterListaDeEstados()
        {
            var estadoRepositorio = new EstadoRepositorio();

            return estadoRepositorio.Listar();
        }
    }
}