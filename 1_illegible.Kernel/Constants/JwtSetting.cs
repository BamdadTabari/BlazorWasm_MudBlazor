using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace illegible.Kernel.Constants
{
    // ok ,  i searched out , i thinked , then I analyzed
    // to find out ==> what is the best way to set this setting
    // at the end figured out the most secure way to do that 
    // is a simple class with setting property in kernel layer of me
    // so i can change them for diffrent situation's
    /// REF: there are some detail about TokenValidationParameters in => "https://docs.microsoft.com/en-us/dotnet/api/microsoft.identitymodel.tokens.tokenvalidationparameters"
    public class JwtSetting
    {
        public bool ValidateIssuerSigningKey { get; set; } = true;
        public bool ValidateLifetime { get; set; } = true;
        public bool ValidateAudience { get; set; } = true;
        public bool ValidateIssuer { get; set; } = true;
        public string ValidIssuer { get; set; } = "https://localhost";
        public string ValidAudience { get; set; } = "https://localhost";
        public string SecuritySignInKey { get; set; } = "WQ7+dPhLEHdhdaKNzu!ck-fg86TPhUfd#E&&Qq+=vUtfxJ!@sDfe#u^prXW2&Qhmy33u!@e?5-xb*";
    }
}
