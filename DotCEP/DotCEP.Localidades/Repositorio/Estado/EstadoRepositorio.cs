using System;
using System.Collections.Generic;

namespace DotCEP.Localidades.Repositorio.Estado
{
    public class EstadoRepositorio : IEstadoRepositorio
    {
        public Localidades.Estado ObterPorCodigo(sbyte codigo)
        {
            throw new NotImplementedException();
        }

        public Localidades.Estado ObterPorSiglaOuNome(string siglaOuNome)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Localidades.Estado> Listar()
        {
            throw new NotImplementedException();
        }
    }
}