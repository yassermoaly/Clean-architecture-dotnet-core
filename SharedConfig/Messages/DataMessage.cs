using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedConfig.Messages
{
    public class DataMessage
    {
        public static dynamic Error(dynamic errors)
        {
            return new { status = "error", Errors = errors };
        }

        public static dynamic Data(dynamic data)
        {
            return new { status = "success", Data = data };
        }

        public static dynamic Message(dynamic messages, string field = "")
        {
            if (field != "")
                return new { messages, field };
            return new { messages };
        }

        public static dynamic Message(dynamic messages, dynamic values, string field = "")
        {
            if (field != "")
                return new { messages, values, field };
            return new { messages, values };
        }
    }
}
