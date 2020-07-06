using Biblioteca.Busisnes.Contracts;
using Biblioteca.Entities;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Biblioteca.Busisnes
{
    public class LibroBusisnes : ILibroBusisnes
    {
        private readonly IConfiguration _configuration;
        private readonly ILibroData _libroData;
        public LibroBusisnes(IConfiguration configuration)
        {
            _configuration = configuration;
            _libroData = new LibroData(_configuration);
        }
        public async Task<bool> DeleteLibro(int idLibro)
            => await _libroData.DeleteLibro(idLibro);

        public async Task<LibroDto> InsertLibro(LibroDto libroDto)
         => await _libroData.InsertLibro(libroDto);

        public async Task<IList<LibroDto>> SelectAllLibro()
            => await _libroData.SelectAllLibro();

        public async Task<LibroDto> UpdateLibro(LibroDto libroDto)
         => await _libroData.UpdateLibro(libroDto);
    }
}
