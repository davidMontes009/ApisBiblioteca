using Biblioteca.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Biblioteca.Entities
{
    public abstract class BaseValidateBulkOperationDto : IValidateBulkOperation
    { 
        public IList<ErrorViewModel> Validations { get; set; } = new List<ErrorViewModel>();

        public bool IsValid => this.Validations.Count == 0;

        public void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
