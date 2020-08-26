using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Limilabs.Client.SMTP;
using Limilabs.Mail;
using Limilabs.Mail.Fluent;

namespace SparkLibrary.Web
{

    public class EmailMessageSender : IMessageService
    {
        public string AttachmentPath { get; set; }
        public string AttachmentFileName { get; set; }
        public string ReceiverAddress { get; set; }
        public string SenderName { get; set; }
        public string EmailSubject { get; set; }
        public string SmtpServer { get; set; }
        public string SmtpLogin { get; set; }
        public string SmtpPassword { get; set; }

        public EmailMessageSender(string attachmentPath, string attachmentFileName, string receiverAddress, string senderName, string emailSubject, string smtpServer, string smtpLogin, string smtpPassword)
        {
            this.AttachmentPath = attachmentPath;
            this.AttachmentFileName = attachmentFileName;
            this.ReceiverAddress = receiverAddress;
            this.SenderName = senderName;
            this.EmailSubject = emailSubject;
            this.SmtpServer = smtpServer;
            this.SmtpLogin = smtpLogin;
            this.SmtpPassword = smtpPassword;
        }

        public void SendMessage()
        {
            IMail email = Mail
                .Html(@"Html ")
                .AddAttachment(AttachmentPath).SetFileName(AttachmentFileName)
                .To(ReceiverAddress)
                .From(SenderName)
                .Subject(EmailSubject)
                .Create();

            using (Smtp smtp = new Smtp())
            {
                smtp.Connect(SmtpServer);  // or ConnectSSL for SSL
                smtp.UseBestLogin(SmtpLogin, SmtpPassword);
                smtp.SendMessage(email);
                if (smtp.SendMessage(email).Status == SendMessageStatus.Success)
                {
                    MessageSent?.Invoke(this, new EventArgs());
                }

                smtp.Close();

            }

        }

        public void ReceiveMessage()
        {
           
        }

        public event SendNotice MessageSent ;
    }
}
