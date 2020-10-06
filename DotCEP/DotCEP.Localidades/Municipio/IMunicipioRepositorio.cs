using System.Collections.Generic;
using DotCEP.Compartilhado.Enumeradores;

namespace DotCEP.Localidades
{
    internal interface IMunicipioRepositorio
    {
        Municipio ObterMunicipio(uint codigo);
        Municipio ObterMunicipio(string nomeMunicipio, string nomeEstado);
        Municipio ObterMunicipio(string nomeMunicipio, UF estado);

        IEnumerable<Municipio> ListarTodos();

        IEnumerable<Municipio> ListarPorEstado(UF estado);
        IEnumerable<Municipio> ListarPorEstado(string nomeEstado);
    }
}