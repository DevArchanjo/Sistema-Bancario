using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaBancario.Entities.Exceptions
{
    internal class DomainException : ApplicationException
    {
        public DomainException(string message) : base(message)
        {        
        }
    }
}
