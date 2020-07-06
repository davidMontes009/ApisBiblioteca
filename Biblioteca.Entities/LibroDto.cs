namespace Biblioteca.Entities
{
    /// <summary>
    /// Modelo de datos de tipo libro 
    /// </summary>
    public class LibroDto : BaseValidateBulkOperationDto
    {
        /// <summary>
        /// Identificador unico del libro
        /// </summary>
        public int IdLibro { get; set; }
        /// <summary>
        /// Numero de volumen 
        /// </summary>
        public string NoVolumen { get; set; }
        /// <summary>
        /// Titulo del libro
        /// </summary>
        public string Titulo { get; set; }
        /// <summary>
        /// ubicacion en cordenadas del libro 
        /// </summary>
        public string IdLocalizacion { get; set; }
    }
}
