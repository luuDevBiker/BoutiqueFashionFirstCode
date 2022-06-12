using DAL.Entities;
using DAL.Reponsitories.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Reponsitories.Implements
{
    public class SendMailService
    {
        private readonly IGenericRepository<user> _userService;
        public SendMailService(IGenericRepository<user> userService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
        }
        public void SendMail(string mail, string pass)
        {
            MailMessage mess = new MailMessage();
            mess.To.Add(mail);
            mess.From = new MailAddress("kienntp038@gmail.com");
            mess.Subject = "Mật khẩu mới";
            mess.Body = "Mật khẩu mới :"+pass;

            SmtpClient smtp = new SmtpClient();
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential("kienntp038@gmail.com", "kien2810");
            var a = _userService.GetAllDataQuery().FirstOrDefault(p => p.Email == mail);
            a.Password = pass;
            _userService.UpdateDataCommand(a);
            try
            {
                smtp.Send(mess);

            }
            catch (Exception e)
            {
                var msg = e.Message;

            }
        }
        public string randomstring(int size, bool a)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToUInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);

            }

            if (a) return builder.ToString().ToLower();
            return builder.ToString();
        }

        public int randomnumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }

}
