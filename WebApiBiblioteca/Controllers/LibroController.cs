using AutoMapper;
using Biblioteca.Busisnes;
using Biblioteca.Busisnes.Contracts;
using Biblioteca.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiBiblioteca.Models;

namespace WebApiBiblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<LibroController> _logger;
        private readonly IMapper _mapper;
        private readonly ILibroBusisnes _libroBusisnes;

        public LibroController(IConfiguration configuration, ILogger<LibroController> logger, IMapper mapper)
        {
            _configuration = configuration;
            _logger = logger;
            _mapper = mapper;
            _libroBusisnes = new LibroBusisnes(_configuration);
        }

        /// <summary>
        /// Servicio para registrar un nuevo libro 
        /// </summary>
        /// <param name="libroModel"> Modelo con la información del libro  </param>
        /// <returns>Mensaje y estatus de la acción </returns>  
        /// <remarks>
        /// Sample request: 
        /// 
        ///     POST     
        ///     {
        ///       "noVolumen": "1A",
        ///       "titulo": "Titulo 1",
        ///       "idLocalizacion": "1"
        ///     }
        ///     
        /// Sample Response
        /// 
        ///     { 
        ///     "message": "El libro se registró con éxito"
        ///     }
        /// </remarks>
        [HttpPost]
        [Route("InsertLibro")]
        public async Task<IActionResult> InsertLibro( LibroModel libroModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LibroDto libro = new LibroDto();
                    libro = await _libroBusisnes.InsertLibro(_mapper.Map<LibroModel, LibroDto>(libroModel));
                    if (libro.Validations.Count > 0)
                        return Ok(new { status = false, mensaje = libro.Validations[0].ErrorMessage.ToString() });


                    return Ok(new { status = false, message = "El libro se registró con éxito" });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Excepción en el controlador LibroController método InsertLibro:", ex);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Api para Actualizar info de un libro 
        /// </summary>
        /// <param name="libroModel">modelo con la informacion del libro </param>
        /// <returns>Estatus de la ccion </returns>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST
        ///     {
        ///       "idLibro": 2,
        ///       "noVolumen": "2BC",
        ///       "titulo": "Titulo 1B",
        ///       "idLocalizacion": "1"
        ///     }
        ///     
        /// Sample Response
        /// 
        ///     { 
        ///     "message": "El libro se actualizo con éxito"
        ///     }
        /// </remarks>
        [HttpPut]
        [Route("UpdateLibro")]
        public async Task<IActionResult> UpdateLibro(LibroModel libroModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    LibroDto libro = new LibroDto();
                    libro = await _libroBusisnes.UpdateLibro(_mapper.Map<LibroModel, LibroDto>(libroModel));
                    if (libro.Validations.Count > 0)
                        return Ok(new { status = false, mensaje = libro.Validations[0].ErrorMessage.ToString() });


                    return Ok(new { status = false, message = "El libro se actualizo con éxito" });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Excepción en el controlador LibroController método UpdateLibro:", ex);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Api para eliminar un libro 
        /// </summary>
        /// <param name="IdLibro">Id del libro </param>
        /// <returns>Estatus de la accrion </returns>
        /// <remarks>
        /// Sample request
        /// 
        ///     POST
        ///     IdLibro = 2
        ///     
        /// Sample response:
        /// 
        ///     {
        ///      "status": true,
        ///      "message": "El libro se borro con éxito"
        ///     }
        /// </remarks>
        [HttpDelete]
        [Route("DeleteLibro")]
        public async Task<IActionResult> DeleteLibro(int IdLibro)
        {
            try
            {
                if (ModelState.IsValid)
                {
                      await _libroBusisnes.DeleteLibro(IdLibro); 

                    return Ok(new { status = true, message = "El libro se borro con éxito" });
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {

                _logger.LogError("Excepción en el controlador LibroController método DeleteLibro:", ex);
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Api para consultar todos los libros 
        /// </summary>
        /// <returns>Retorna lista de libros</returns>
        /// <remarks>
        /// Sample request:
        ///    
        ///     GET
        ///     El servicio no requiere parametros 
        ///     
        /// Sample Response 
        /// 
        ///     
        /// </remarks>
        [HttpGet]
        [Route("GetAllLibros")]
        public async Task<IActionResult> GetAllLibros()
        {
            try
            { 
                    IList<LibroDto> listLibros = await _libroBusisnes.SelectAllLibro();

                    return Ok(listLibros);
                
            }
            catch (Exception ex)
            {

                _logger.LogError("Excepción en el controlador LibroController método GetAllLibros:", ex);
                return BadRequest(ex);
            }
        }
    }
}
