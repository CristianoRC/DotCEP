using System.Collections.Generic;

namespace DotCEP.Localidades.Repositorio.Estado
{
    public interface IEstadoRepositorio
    {
        DotCEP.Localidades.Estado ObterPorCodigo(sbyte codigo);
        DotCEP.Localidades.Estado ObterPorSiglaOuNome(string siglaOuNome);
        IEnumerable<DotCEP.Localidades.Estado> Listar();
    }
}