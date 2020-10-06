using System;
using System.Collections.Generic;
using DotCEP.Compartilhado.Enumeradores;

namespace DotCEP.Localidades
{
    public class Municipio
    {
        private readonly IMunicipioRepositorio _municipioRepositorio;

        public Municipio()
        {
            _municipioRepositorio = new MunicipioRepositorio();
        }

        public Municipio(uint codigo) : this()
        {
            try
            {
                var municipioTemp = _municipioRepositorio.ObterMunicipio(codigo);

                Codigo = municipioTemp.Codigo;
                codigoEstado = municipioTemp.codigoEstado;
                Nome = municipioTemp.Nome;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Municipio(string nomeMunicipio, UF siglaEstado) : this()
        {
            var municipioTemp = _municipioRepositorio.ObterMunicipio(nomeMunicipio, siglaEstado);

            Codigo = municipioTemp.Codigo;
            codigoEstado = municipioTemp.codigoEstado;
            Nome = municipioTemp.Nome;
        }

        public Municipio(string nomeMunicipio, string nomeEstado) : this()
        {
            var municipioTemp = _municipioRepositorio.ObterMunicipio(nomeMunicipio, nomeEstado);

            Codigo = municipioTemp.Codigo;
            codigoEstado = municipioTemp.codigoEstado;
            Nome = municipioTemp.Nome;
        }

        public uint Codigo { get; }

        public string Nome { get; }

        public UF Estado => (UF) codigoEstado;

        private byte codigoEstado { get; }


        public static IEnumerable<Municipio> ListarTodos()
        {
            var municipioRepositorio = new MunicipioRepositorio();
            return municipioRepositorio.ListarTodos();
        }

        public static IEnumerable<Municipio> ListarPorEstado(UF siglaEstado)
        {
            var municipioRepositorio = new MunicipioRepositorio();
            return municipioRepositorio.ListarPorEstado(siglaEstado);
        }

        public static IEnumerable<Municipio> ListarPorEstado(string nomeEstado)
        {
            var municipioRepositorio = new MunicipioRepositorio();
            return municipioRepositorio.ListarPorEstado(nomeEstado);
        }
    }
}