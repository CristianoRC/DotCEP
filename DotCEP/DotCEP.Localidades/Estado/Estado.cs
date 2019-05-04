using System;
using System.Collections.Generic;
using DotCEP.Localidades.Repositorio.Estado;

namespace DotCEP.Localidades
{
    public class Estado
    {
        private readonly IEstadoRepositorio _estadoRepositorio;


        public Estado()
        {
        }

        public Estado(string SiglaOuNome)
        {
            _estadoRepositorio = new EstadoRepositorio();

            if (SiglaOuNome.Trim().Length == 2) SiglaOuNome = SiglaOuNome.Trim().ToUpper();

            try
            {
                var estadoTemp = _estadoRepositorio.ObterPorSiglaOuNome(SiglaOuNome);

                Codigo = estadoTemp.Codigo;
                Nome = estadoTemp.Nome;
                Sigla = estadoTemp.Sigla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Estado(sbyte codigo)
        {
            _estadoRepositorio = new EstadoRepositorio();

            try
            {
                var estadoTemp = _estadoRepositorio.ObterPorCodigo(codigo);

                Codigo = estadoTemp.Codigo;
                Nome = estadoTemp.Nome;
                Sigla = estadoTemp.Sigla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public sbyte Codigo { get; }

        public string Sigla { get; }

        public string Nome { get; }


        public static IEnumerable<Estado> ObterListaDeEstados()
        {
            IEstadoRepositorio _estadoRepositorio = new EstadoRepositorio();

            try
            {
                return _estadoRepositorio.Listar();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}