using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Shared.SharedDto.Identity
{
    public class RegisterResultDto
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
