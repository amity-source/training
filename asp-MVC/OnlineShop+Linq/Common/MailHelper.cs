using System.Configuration;
using System.Net;
using System;

namespace Common
{
    public class MailHelper
    {
        public void SendMail(string toEmail, string subject, string content)
        {
            string EmailAddress = ConfigurationManager.AppSettings["FromEmailAddress"].ToString();
        }
    }
}
