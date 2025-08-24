using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Communication.Email;

namespace AppLogic
{
    public class AdminEmail
    {
        public async Task<string> SendEmail(string emailAddress)
        {
            string connectionString = "endpoint=https://communicationserviceisaias.unitedstates.communication.azure.com/;accesskey=#REPLACE";
            EmailClient emailClient = new EmailClient(connectionString);

            EmailContent emailContent = new EmailContent("Vacation Requests");
            emailContent.PlainText = "Vacation Requests Registered.";


            List<EmailAddress> emailAddresses = new List<EmailAddress> { new EmailAddress(emailAddress, "Employee Perks Isaias") };
            EmailRecipients emailRecipients = new EmailRecipients(emailAddresses);
            
            
            EmailMessage emailMessage = new EmailMessage("donotreply@574a5e20-8730-4760-8c6f-412816e482ce.azurecomm.net", emailRecipients, emailContent);


            EmailSendOperation emailSendOperation = await emailClient.SendAsync(
                                                    WaitUntil.Completed,
                                                                emailMessage, CancellationToken.None);
            EmailSendResult statusMonitor = emailSendOperation.Value;

            Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

            return emailSendOperation.Value.Status.ToString();
        }
    }
}

