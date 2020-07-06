using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Shared.Enums
{
    /// <summary>
    /// Representa las operaciones que se pueden realizar por medio de un Stored Procedure.
    /// </summary>
    public enum OperationBD
    {
        /// <summary>
        /// Representa la inserción de registros.
        /// </summary>
        INSERT = 1,
        /// <summary>
        /// Representa la modificación de uno o varios registros.
        /// </summary>
        UPDATE = 2,
        /// <summary>
        /// Representa la eliminación fisica o lógica de uno o varios registros segun la condición.
        /// </summary>
        DELETE = 3,
        /// <summary>
        /// Representa la obtención de información de una fuente de datos (BD), el resultado es un solo registro
        /// </summary>
        SELECTFIRST = 4,
        /// <summary>
        /// Representa la obtención de todos los registros que cumplan con la condición
        /// </summary>
        SELECTALL = 5,

        VALIDATIONeXTRA = 6
    }
}
