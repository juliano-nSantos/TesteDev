using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.ConfigFilters
{
    public class ValidateInputViewModel
    {
        public IEnumerable<string> Errors { get; private set; }

        public ValidateInputViewModel(IEnumerable<string> _errors)
        {
            Errors = _errors;
        }
    }
}