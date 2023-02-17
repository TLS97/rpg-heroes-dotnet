using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGHeroes.Exceptions
{
    public class InsufficientLevelException : Exception
    {
        public InsufficientLevelException(string? message) : base(message)
        {
        }
    }
}
