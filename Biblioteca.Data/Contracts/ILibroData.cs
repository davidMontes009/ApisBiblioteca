using Biblioteca.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Busisnes.Contracts
{
    public interface ILibroData
    {
        /// <summary>
        /// Metodo para registrar un libro 
        /// </summary>
        /// <param name="libroDto">Modelo con la informacion del libro </param>
        /// <returns>Estatus de la accion </returns>
        Task<LibroDto> InsertLibro(LibroDto libroDto);
        /// <summary>
        /// Metodo para actualizar un libro 
        /// </summary>
        /// <param name="libroDto">Modelo con la informacion del libro </param>
        /// <returns>Estatus de la accion </returns>
          Task<LibroDto> UpdateLibro(LibroDto libroDto);
        /// <summary>
        /// Metodo para eliminar un libro 
        /// </summary>
        /// <param name="idLibro">Id del libro a eliminar </param>
        /// <returns>estatus de la accion</returns>
        Task<bool> DeleteLibro(int idLibro);
        /// <summary>
        /// Metodo para consultar todos los libros 
        /// </summary>
        /// <returns>rRetorna lista de libros </returns>
        Task<IList<LibroDto>> SelectAllLibro();
    }
}
