using System.Collections.Generic;

namespace DotCEP.Localidades.Repositorio.Estado
{
    internal interface IEstadoRepositorio
    {
        Localidades.Estado ObterPorCodigo(sbyte codigo);
        Localidades.Estado ObterPorSiglaOuNome(string siglaOuNome);
        IEnumerable<Localidades.Estado> Listar();
    }
}