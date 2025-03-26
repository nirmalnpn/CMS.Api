using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models.Model;
using CMS.Models.Requestmodel.User;

namespace DAL.Interface.Users
{
    internal class IOtpRepository
    {
        Task<EmailResult> SendEmailAsync(string to, String Subject, String Body);
    }
}
