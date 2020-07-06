using AutoMapper;
using Biblioteca.Entities;
using WebApiBiblioteca.Models;

namespace WebApiBiblioteca.Services
{
    /// <summary>
    /// Clase para realizar el automapper 
    /// </summary>
    public class MappingProfile : Profile
    {
        /// <summary>
        /// constructor
        /// </summary>
        public MappingProfile()
        {
            CreateMap<LibroModel, LibroDto>().ReverseMap(); 
        }
    }
}
