using System.ComponentModel.DataAnnotations;

namespace WebApiBiblioteca.Models
{
    /// <summary>
    /// Modelo de tipo libro  para realizar validaciones de datos 
    /// </summary>
    public class LibroModel
    {
        /// <summary>
        /// Identificador unico del libro
        /// </summary>
        public int IdLibro { get; set; }
        /// <summary>
        /// Numero de volumen 
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        public string NoVolumen { get; set; }
        /// <summary>
        /// Titulo del libro
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        public string Titulo { get; set; }
        /// <summary>
        /// ubicacion en cordenadas del libro 
        /// </summary>
        [Required(ErrorMessage = "Campo requerido")]
        public string IdLocalizacion { get; set; }
    }
}
