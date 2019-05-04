using System;
using System.Collections.Generic;
using DotCEP.Localidades.Repositorio.Municipio;

namespace DotCEP.Localidades
{
    public class Municipio
    {
        private readonly IMunicipioRepositorio _municipioRepositorio;

        public Municipio()
        {
        }

        public Municipio(uint codigo)
        {
            _municipioRepositorio = new MunicipioRepositorio();
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

        public Municipio(string nomeMunicipio, UF siglaEstado)
        {
            _municipioRepositorio = new MunicipioRepositorio();
            try
            {
                var municipioTemp = _municipioRepositorio.ObterMunicipio(nomeMunicipio, siglaEstado);

                Codigo = municipioTemp.Codigo;
                codigoEstado = municipioTemp.codigoEstado;
                Nome = municipioTemp.Nome;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Municipio(string nomeMunicipio, string nomeEstado)
        {
            _municipioRepositorio = new MunicipioRepositorio();

            try
            {
                var municipioTemp = _municipioRepositorio.ObterMunicipio(nomeMunicipio, nomeEstado);

                Codigo = municipioTemp.Codigo;
                codigoEstado = municipioTemp.codigoEstado;
                Nome = municipioTemp.Nome;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public uint Codigo { get; }

        public string Nome { get; }

        public UF Estado => (UF) codigoEstado;

        private byte codigoEstado { get; }


        public static IEnumerable<Municipio> ListarTodos()
        {
            IMunicipioRepositorio _municipioRepositorio = new MunicipioRepositorio();

            try
            {
                return _municipioRepositorio.ListarTodos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<Municipio> ListarPorEstado(UF siglaEstado)
        {
            IMunicipioRepositorio _municipioRepositorio = new MunicipioRepositorio();

            try
            {
                return _municipioRepositorio.ListarPorEstado(siglaEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<Municipio> ListarPorEstado(string nomeEstado)
        {
            IMunicipioRepositorio _municipioRepositorio = new MunicipioRepositorio();

            try
            {
                return _municipioRepositorio.ListarPorEstado(nomeEstado);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}