using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMailService
    {
        Task<bool> SendClassicEmail(List<string> to, string subject, string message, List<string> cc = null, List<string> bcc = default);
    }
}
