using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Shared
{
    public interface IValidate
    {
        IList<ErrorViewModel> Validations { get; set; }

        bool IsValid { get; }

        void Validate();
    }
}
