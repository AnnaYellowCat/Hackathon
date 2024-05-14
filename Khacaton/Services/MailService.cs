using Khacaton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Khacaton.Services
{
    public class MailService
    {
        public static void sendMessage(Accounts account, string sub, string body)
        {
            SmtpClient smtpClient = new SmtpClient("smpt.mail.ru");
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential("nekit0313@list.ru", "VfxWmany8SjjaB8BCwfh");

            Students student = AuthService.getStudent(account.idStudent);
            string to = student.email;
            string from = "nekit0313@list.ru";

            MailMessage mailMessage = new MailMessage(from, to, sub, body);

            smtpClient.Send(mailMessage);
        }
    }
}