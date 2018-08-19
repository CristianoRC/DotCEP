using System;
using System.Collections.Generic;
using DotCEP.Localidades.Repositorio.Estado;

namespace DotCEP.Localidades
{
    public class Estado
    {
        private readonly IEstadoRepositorio _estadoRepositorio;


        public Estado(string SiglaOuNome)
        {
            _estadoRepositorio = new EstadoRepositorio();

            if (SiglaOuNome.Trim().Length == 2)
            {
                SiglaOuNome = SiglaOuNome.Trim().ToUpper();
            }

            try
            {
                var estadoTemp = _estadoRepositorio.ObterPorSiglaOuNome(SiglaOuNome);

                this.Codigo = estadoTemp.Codigo;
                this.Nome = estadoTemp.Nome;
                this.Sigla = estadoTemp.Sigla;
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

                this.Codigo = estadoTemp.Codigo;
                this.Nome = estadoTemp.Nome;
                this.Sigla = estadoTemp.Sigla;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public SByte Codigo { get; private set; }

        public String Sigla { get; private set; }

        public String Nome { get; private set; }


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