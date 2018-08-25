using System.Collections.Generic;
using DotCEP.Enumeradores;

namespace DotCEP.Localidades.Repositorio.Municipio
{
    internal interface IMunicipioRepositorio
    {
        Localidades.Municipio ObterMunicipio(uint codigo);
        Localidades.Municipio ObterMunicipio(string nomeMunicipio, string nomeEstado);
        Localidades.Municipio ObterMunicipio(string nomeMunicipio, UF Estado);

        IEnumerable<Localidades.Municipio> ListarTodos();
        
        IEnumerable<Localidades.Municipio> ListarPorEstado(UF estado);
        IEnumerable<Localidades.Municipio> ListarPorEstado(string nomeEstado);
    }
}