using AuctionSite.Shared.BindingModel;
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

        public void SendMessage(RegisterUserBindingModel userModel)
        {
            var apiKey = _configuration.GetSection("send-grid-api-key").GetSection("Default").Value;
            var client = new SendGridClient(apiKey);

            var msg = new SendGridMessage();

            msg.SetFrom(new EmailAddress("damian.jacyna@billennium.com", "Auction Site Team"));

            var messageDto = new EmailMessageDto()
            {
                Content = CreateContent(userModel.FirstName),
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                Subject = "Auction Site - link weryfikacyjny"
            };

            CreateMessage(msg, messageDto);

            client.SendEmailAsync(msg);
        }

        private string CreateContent(string name)
        {
            var content = $@"<h3>Hej {name}</h3>
                        Nawet nie masz pojęcia jak bardzo cieszymy się, że chcesz założyć konto na naszym portalu! :) <br><br>

                        Kliknij w poniższy link, aby zweryfikować swoje konto <br>
                        Link
                        <br><br>
                        Pozdrawiamy! <br>
                        Auction Site Team";
            return content;
        }

        private string CreateActivationLink()
        {
            throw new NotImplementedException();
        }

        private void CreateMessage(SendGridMessage messageObject, EmailMessageDto emailMessageDto)
        {
            messageObject.AddTo(new EmailAddress(emailMessageDto.Email));

            messageObject.SetSubject(emailMessageDto.Subject);

            messageObject.AddContent(MimeType.Html, emailMessageDto.Content);
        }
    }
}
