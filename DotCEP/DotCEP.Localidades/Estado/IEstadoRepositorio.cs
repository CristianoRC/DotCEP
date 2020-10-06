using System.Collections.Generic;

namespace DotCEP.Localidades
{
    internal interface IEstadoRepositorio
    {
        Estado ObterPorCodigo(sbyte codigo);
        Estado ObterPorSiglaOuNome(string siglaOuNome);
        IEnumerable<Estado> Listar();
    }
}