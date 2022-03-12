using Experimental.System.Messaging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace CommonLayer.Model
{
    public class Msmq
    {
        MessageQueue messageQueue = new MessageQueue();
        public void Sender(string token)
        {
            this.messageQueue.Path = @".\private$\Tokens";
            try
            {
                if (!MessageQueue.Exists(this.messageQueue.Path)) 
                {
                    MessageQueue.Create(this.messageQueue.Path);
                }
                this.messageQueue.Formatter = new XmlMessageFormatter(new Type[] { typeof(string) });
                this.messageQueue.ReceiveCompleted += MessageQueue_ReceiveCompleted;
                this.messageQueue.Send(token);
                this.messageQueue.BeginReceive();
                this.messageQueue.Close();




            }
            catch (Exception)
            {

                throw;
            }

           
        }
        private void MessageQueue_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            var message = this.messageQueue.EndReceive(e.AsyncResult);
            string token = message.Body.ToString();
            try
            {
                MailMessage mailMessage = new MailMessage();
                SmtpClient smtpclient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("joekohli17@gmail.com", "joe@1432"),
                    EnableSsl = true


                };
                mailMessage.From = new MailAddress("joekohli17@gmail.com");
                mailMessage.To.Add(new MailAddress("joekohli17@gmail.com"));
                mailMessage.Body = token;
                mailMessage.Subject = "FundooNote App reset Link";
                smtpclient.Send(mailMessage);


            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
