using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedConfig.Config
{
    public class DBOptions
    {
        public string ConnectionString { get; set; }
        public int DeservedBulk { get; set; }
    }
}
