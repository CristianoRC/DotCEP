using System;
using System.Collections.Generic;
using DotCEP.Enumeradores;
using DotCEP.Localidades.Repositorio.Municipio;

namespace DotCEP.Localidades
{
    public class Municipio
    {
        private readonly IMunicipioRepositorio _municipioRepositorio;

        public uint Codigo { get; private set; }

        public string Nome { get; private set; }

        public UF Estado
        {
            get { return (UF) codigoEstado; }
        }

        private byte codigoEstado { get; set; }

        public Municipio()
        {
        }

        public Municipio(uint codigo)
        {
            _municipioRepositorio = new MunicipioRepositorio();
            try
            {
                var municipioTemp = _municipioRepositorio.ObterMunicipio(codigo);

                this.Codigo = municipioTemp.Codigo;
                this.codigoEstado = municipioTemp.codigoEstado;
                this.Nome = municipioTemp.Nome;
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

                this.Codigo = municipioTemp.Codigo;
                this.codigoEstado = municipioTemp.codigoEstado;
                this.Nome = municipioTemp.Nome;
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

                this.Codigo = municipioTemp.Codigo;
                this.codigoEstado = municipioTemp.codigoEstado;
                this.Nome = municipioTemp.Nome;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


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