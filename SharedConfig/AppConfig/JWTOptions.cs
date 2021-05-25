using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedConfig.Config
{
    public class JWTOptions
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public int Expires { get; set; }
        public string Secret { get; set; }
    }
}
