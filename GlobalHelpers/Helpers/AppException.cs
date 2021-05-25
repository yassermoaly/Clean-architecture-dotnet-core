using SharedConfig.Messages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GlobalHelpers.Helpers
{
    public class AppException : Exception
    {
        public dynamic args;
        public string field;
        public AppException() : base() { }

        public AppException(string message, string field = "")
            : base(message) { this.field = field; }

        public AppException(string message, dynamic args, string field = "")
            : base(message) { this.args = args; this.field = field; }

        public AppException(string message, params object[] args)
            : base(string.Format(CultureInfo.CurrentCulture, message, args)) { }

        public object ReturnBadRequest()
        {
            if (args != null)
                return DataMessage.Error(DataMessage.Message(new string[] { Message }, args, field));
            return DataMessage.Error(DataMessage.Message(new string[] { Message }, field));
        }

        public static object ReturnBadRequest(string message)
        {
            return DataMessage.Error(DataMessage.Message(new string[] { message }));
        }

        public static object ReturnBadRequest(ModelStateDictionary ModelState)
        {
            List<string> errors = new();
            foreach (ModelStateEntry modelState in ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }
            }

            return DataMessage.Error(DataMessage.Message(errors));
        }
    }
}
