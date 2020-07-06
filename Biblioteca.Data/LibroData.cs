using Biblioteca.Busisnes.Contracts;
using Biblioteca.Entities;
using Biblioteca.Shared;
using Biblioteca.Shared.Enums;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Transactions;

namespace Biblioteca.Busisnes
{
    public class LibroData : ILibroData
    {
        private readonly IConfiguration _configuration;

        public LibroData(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Metodo para registrar un libro 
        /// </summary>
        /// <param name="libroDto">Modelo con la informacion del libro </param>
        /// <returns>Estatus de la accion </returns>
        public async Task<LibroDto> InsertLibro(LibroDto libroDto)
        {
            try
            {
                LibroDto objLibroDto = new LibroDto();
                using (var transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.FromMinutes(15), TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (var connection = new SqlConnection(_configuration["ConnectionStrings:ConnectionLocal"]))
                    {
                        using (var command = connection.CreateSpCommand(_configuration["StoresProcedures:SP_Libro"], OperationBD.INSERT))
                        {
                            command.AddSqlParameter("@NoVolumen",       libroDto.NoVolumen);
                            command.AddSqlParameter("@Titulo",          libroDto.Titulo);
                            command.AddSqlParameter("@IdLocalizacion",  libroDto.IdLocalizacion);

                            ///Valida que la conexion este abierta
                            if (connection.State == ConnectionState.Closed)
                            {
                                connection.Open();
                            }

                            ///Inicializa nueva instancia de la clase SqlDataAdapter con el objeto SqlCommand como parametro 
                            var _adapter = new SqlDataAdapter(command);
                            var _dataSet = new DataSet();
                            _adapter.Fill(_dataSet);

                            ///MApea errores 
                            foreach (DataRow row in _dataSet.Tables[0].Rows)
                            {
                                connection.Close();
                                ErrorViewModel errorView = new ErrorViewModel()
                                {
                                    ErrorMessage = row.ItemArray[0].ToString()
                                };

                                objLibroDto.Validations.Add(errorView);
                                return await Task.FromResult(objLibroDto);
                            }

                            ///Mapea resoueta 
                            foreach (DataRow row in _dataSet.Tables[1].Rows)
                            {
                                objLibroDto = new LibroDto()
                                {
                                    IdLibro         = int.Parse(row.ItemArray[0].ToString().Trim()), 
                                    NoVolumen       = row.ItemArray[0].ToString().Trim(),
                                    Titulo          = row.ItemArray[0].ToString().Trim(),
                                    IdLocalizacion  = row.ItemArray[0].ToString().Trim()
                                };
                            }
                        }
                        connection.Close();
                    }
                    transactionScope.Complete();
                }
                return await Task.FromResult(objLibroDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo para actualizar un libro 
        /// </summary>
        /// <param name="libroDto">Modelo con la informacion del libro </param>
        /// <returns>Estatus de la accion </returns>
        public async Task<LibroDto> UpdateLibro(LibroDto libroDto)
        {
            try
            {
                LibroDto objLibroDto = new LibroDto();
                using (var transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.FromMinutes(15), TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (var connection = new SqlConnection(_configuration["ConnectionStrings:ConnectionLocal"]))
                    {
                        using (var command = connection.CreateSpCommand(_configuration["StoresProcedures:SP_Libro"], OperationBD.UPDATE))
                        {
                            command.AddSqlParameter("@NoVolumen",        libroDto.NoVolumen);
                            command.AddSqlParameter("@Titulo",           libroDto.Titulo);
                            command.AddSqlParameter("@IdLocalizacion",   libroDto.IdLocalizacion);
                            command.AddSqlParameter("@IdLibro",          libroDto.IdLibro);

                            ///Valida que la conexion este abierta
                            if (connection.State == ConnectionState.Closed) 
                                connection.Open(); 

                            ///Inicializa nueva instancia de la clase SqlDataAdapter con el objeto SqlCommand como parametro 
                            var _adapter = new SqlDataAdapter(command);
                            var _dataSet = new DataSet();
                            _adapter.Fill(_dataSet);

                            ///MApea errores 
                            foreach (DataRow row in _dataSet.Tables[0].Rows)
                            {
                                connection.Close();
                                ErrorViewModel errorView = new ErrorViewModel()
                                {
                                    ErrorMessage = row.ItemArray[0].ToString()
                                };

                                objLibroDto.Validations.Add(errorView);
                                return await Task.FromResult(objLibroDto);
                            }

                            ///Mapea resoueta 
                            foreach (DataRow row in _dataSet.Tables[1].Rows)
                            {
                                objLibroDto = new LibroDto()
                                {
                                    IdLibro     = int.Parse(row.ItemArray[0].ToString().Trim()),
                                    NoVolumen   = row.ItemArray[1].ToString().Trim(),
                                    Titulo      = row.ItemArray[2].ToString().Trim()
                                };
                            }
                        }
                        connection.Close();
                    }
                    transactionScope.Complete();
                }
                return await Task.FromResult(objLibroDto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Metodo para eliminar un libro 
        /// </summary>
        /// <param name="idLibro">Id del libro a eliminar </param>
        /// <returns>estatus de la accion</returns>
        public async Task<bool> DeleteLibro(int  idLibro)
        {
            try
            {
                bool _result = false;
                using (var transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.FromMinutes(15), TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (var connection = new SqlConnection(_configuration["ConnectionStrings:ConnectionLocal"]))
                    {
                        using (var command = connection.CreateSpCommand(_configuration["StoresProcedures:SP_Libro"], OperationBD.DELETE))
                        {
                            command.AddSqlParameter("@IdLibro", idLibro);

                            ///Valida que la conexion
                            if (connection.State == ConnectionState.Closed)
                                connection.Open();

                            ///Inicializa nueva instancia de la clase SqlDataAdapter con el objeto SqlCommand como parametro 
                            var _adapter = new SqlDataAdapter(command);
                            var _dataSet = new DataSet();
                            _adapter.Fill(_dataSet);

                            _result = true;
                        }
                        connection.Close();
                    }
                    transactionScope.Complete();
                }
                return await Task.FromResult(_result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       /// <summary>
       /// Metodo para consultar todos los libros 
       /// </summary>
       /// <returns>rRetorna lista de libros </returns>
        public async Task<IList<LibroDto>> SelectAllLibro()
        {
            try
            {
                IList<LibroDto> listLirbo = new List<LibroDto>();
                LibroDto objLibroDto = new LibroDto();
                using (var transactionScope = new TransactionScope(TransactionScopeOption.RequiresNew, TimeSpan.FromMinutes(15), TransactionScopeAsyncFlowOption.Enabled))
                {
                    using (var connection = new SqlConnection(_configuration["ConnectionStrings:ConnectionLocal"]))
                    {
                        using (var command = connection.CreateSpCommand(_configuration["StoresProcedures:SP_Libro"], OperationBD.SELECTALL))
                        { 

                            ///Valida que la conexion este abierta
                            if (connection.State == ConnectionState.Closed)
                                connection.Open();

                            ///Inicializa nueva instancia de la clase SqlDataAdapter con el objeto SqlCommand como parametro 
                            var _adapter = new SqlDataAdapter(command);
                            var _dataSet = new DataSet();
                            _adapter.Fill(_dataSet); 

                            ///Mapea resoueta 
                            foreach (DataRow row in _dataSet.Tables[0].Rows)
                            { 
                                objLibroDto = new LibroDto()
                                {
                                    IdLibro         = int.Parse(row.ItemArray[0].ToString().Trim()),
                                    NoVolumen       = row.ItemArray[1].ToString().Trim(),
                                    Titulo          = row.ItemArray[2].ToString().Trim(),
                                    IdLocalizacion  = row.ItemArray[3].ToString().Trim()
                                };

                                listLirbo.Add(objLibroDto);
                            }
                        }
                        connection.Close();
                    }
                    transactionScope.Complete();
                }
                return await Task.FromResult(listLirbo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
