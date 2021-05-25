using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedConfig.Config
{
    public class AppConfig
    {
        public SmtpOptions Smtp { get; set; }
        public CustomLoggingOptions CustomLogging { get; set; }
        public DBOptions DBConfig { get; set; }
        public JWTOptions JWTConfig { get;set;}
        public SecurityKeys Keys { get; set; }
    }
}
