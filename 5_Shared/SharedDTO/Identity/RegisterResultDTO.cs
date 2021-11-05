using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Shared.SharedDTO.Identity
{
    public class RegisterResultDTO
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
