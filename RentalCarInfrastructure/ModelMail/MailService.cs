using Mailjet.Client;
using Mailjet.Client.Resources;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RentalCarInfrastructure.ModelMail
{
    public class MailService : IMailService
    {
        private readonly IMailjetClient _client;
        public MailService(IMailjetClient client)
        {
            _client = client;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            try
            {
                string mail = mailRequest.ToEmail;
                MailjetRequest request = new MailjetRequest { Resource = SendV31.Resource }
                .Property(Send.Messages, new JArray {
                    new JObject
                    {
                        {
                           "From",new JObject
                           {
                              {"Email","sq010dotnet@gmail.com"},
                              {"Name", "Rental Car"}
                           }
                        },
                        {
                            "To", new JArray
                            {
                               new JObject
                               {
                                  {"Email", mail },
                               }
                            }
                        },
                      {"Subject", mailRequest.Subject},
                      { "HtmlPart",  $@"{mailRequest.Body}" },
                      {"CustomId", "AppGettingStartedTest"}
                    }
                });
                MailjetResponse response = await _client.PostAsync(request);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public string GetEmailTemplate(string templateName)
        {
            var baseDir = Directory.GetCurrentDirectory();
            string folderName = "/StaticFiles/";
            var path = Path.Combine(baseDir + folderName, templateName);
            return File.ReadAllText(path);
        }
        //private readonly MailSettings _mailSettings;
        //public MailService(IOptions<MailSettings> mailSettings)
        //{
        //    _mailSettings = mailSettings.Value;
        //}

        //public async Task SendEmailAsync(MailRequest mailRequest)
        //{
        //    using var email = new MimeMessage()
        //    {
        //        Sender = MailboxAddress.Parse(_mailSettings.Mail),
        //        Subject = mailRequest.Subject,
        //    };

        //    email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
        //    var builder = new BodyBuilder();

        //    if (mailRequest.Attachments != null)
        //    {
        //        byte[] fileBytes;
        //        foreach (var file in mailRequest.Attachments)
        //        {
        //            if (file.Length > 0)
        //            {
        //                using (var stream = new MemoryStream())
        //                {
        //                    file.CopyTo(stream);
        //                    fileBytes = stream.ToArray();
        //                }
        //                builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
        //            }
        //        }
        //    }

        //    builder.HtmlBody = mailRequest.Body;
        //    email.Body = builder.ToMessageBody();
        //    using var smtp = new SmtpClient();
        //    smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
        //    smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
        //    await smtp.SendAsync(email);
        //    smtp.Disconnect(true);
        //}
        //public string GetEmailTemplate(string templateName)
        //{
        //    var baseDir = Directory.GetCurrentDirectory();
        //    string folderName = "/StaticFiles/";
        //    var path = Path.Combine(baseDir + folderName, templateName);
        //    return File.ReadAllText(path);
        //}
    }
}