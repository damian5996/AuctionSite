using AuctionSite.Shared.Dto;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuctionSite.BL.Common.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMessage()
        {
            var apiKey = _configuration.GetSection("send-grid-api-key").GetSection("Default").Value;
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("damianjacyna59@gmail.com", "Your Auction Site Team"));

            //var recipients = new List<EmailAddress>
            //{
            //    new EmailAddress("damianjacyna59@gmail.com", "Damian Jacyna")
            //};
            var messageDto = new EmailMessageDto()
            {
                Content = "Hej, to jest treść mojego emaila!",
                Email = "damian.jacyna@billennium.com",
                FullName = "Damian Jacyna z Billennium",
                Subject = "Temat emaila"
            };

            CreateMessage(msg, messageDto);

            client.SendEmailAsync(msg);
        }

        private void CreateMessage(SendGridMessage messageObject, EmailMessageDto emailMessageDto)
        {
            messageObject.AddTo(new EmailAddress(emailMessageDto.Email, emailMessageDto.FullName));

            messageObject.SetSubject(emailMessageDto.Subject);

            messageObject.AddContent(MimeType.Html, emailMessageDto.Content);
        }
    }
}
