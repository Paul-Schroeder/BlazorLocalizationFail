using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using Microsoft.JSInterop;
using SprayCalc.Client.ResourceFiles;
using System;

namespace SprayCalc.Client.ViewModels
{
    public class BaseSprayCalcViewModel : ComponentBase
    {
        [Inject]
        protected IJSRuntime JsRuntime { get; set; }

        [Inject]
        protected IStringLocalizer<Resource> Localizer { get; set; }

        protected void SendLocalEmail(string toEmailAddress, string subject, string body)
        {
            try
            {
                // <a href="mailto:someone@yoursite.com?cc=someoneelse@theirsite.com, another@thatsite.com, me@mysite.com&bcc=lastperson@theirsite.com&subject=Test%20Subject&body=Body-goes-here">Email Us</a>
                JsRuntime.InvokeAsync<object>("blazorExtensions.SendLocalEmail",
                    new object[] { toEmailAddress, subject, body });
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// The following code is a placeholder for if we want to develop online capabilities for sending emails using something like FluentEmail
        /// </summary>
        /// <param name="toEmailAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        protected async void SendOnlineEmailAsync(string toEmailAddress, string subject, string body)
        {
            throw new NotImplementedException("Client-side Blazor (WASM) is not capable of using classes like SmtpClient");
            //try
            //{
            //    var sender = new SmtpSender(() => new SmtpClient("localhost")
            //    {
            //        //EnableSsl = false,
            //        //DeliveryMethod = SmtpDeliveryMethod.Network,
            //        //Port = 25,
            //        DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
            //        PickupDirectoryLocation = @"C:\ptemp\MSCTekEmails"
            //    });

            //    Email.DefaultSender = sender;

            //    StringBuilder template = new();
            //    template.AppendLine("<p>Attached are your calculations</p>");

            //    var email = await Email
            //        .From("Paul@MSCTek.com")
            //        .To(toEmailAddress)
            //        .Subject(subject)
            //        .UsingTemplate(template.ToString(), new { FirstName = "Paul", ProductName = "Whateves" })
            //        .SendAsync();
            //}
            //catch (Exception ex)
            //{
            //    throw;
            //}
        }
    }
}