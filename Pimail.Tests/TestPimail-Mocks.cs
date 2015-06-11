using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.IO;

using System.Net.Mail;

using PI.Pimail.Models;

namespace PI.Pimail.Tests
{
    public partial class TestPimail
    {
        private Email GetEmail(string name = "test-email")
        {
            //create a clone of this object
            Email em = new Email()
            {
                Id = name,
                Name = name,
                To = "pete.cleary@gmail.com",
                Subject = "Hi [NAME]",
                BodyHtml = "<h1>Hi [NAME]</h1><p>How are you? [SUB_NAME]</p><ul>[NAMES_START]<li>[FIRSTNAME] [LASTNAME]</li>[NAMES_END]</ul>",
                BodyPlain = "Hi [NAME]\n\nHow are you? [SUB_NAME]. [NAMES_START][FIRSTNAME] [LASTNAME],[NAMES_END]",
                IsBodyHtml = true,
                From = "pete.cleary@gmail.com",
                FromDisplay = "Pete Cleary"
            };
            em.Id = em.StringToId(em.Name);
            em.SetCreate("Test");
            return em;
        }

        private string OutputDirectory = AppDomain.CurrentDomain.BaseDirectory + "/Output";
        private string XmlMailDirectory = AppDomain.CurrentDomain.BaseDirectory + "/XmlMail";

        private void CleanOutput()
        {
            DirectoryInfo downloadedMessageInfo = new DirectoryInfo(OutputDirectory);

            foreach (FileInfo file in downloadedMessageInfo.GetFiles())
            {
                file.Delete();
            }
            foreach (DirectoryInfo dir in downloadedMessageInfo.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        private void CreateDirectories()
        {
            if (!Directory.Exists(OutputDirectory)) Directory.CreateDirectory(OutputDirectory);
            if (!Directory.Exists(XmlMailDirectory)) Directory.CreateDirectory(XmlMailDirectory);
        }

        private SmtpClient GetSmtpClient()
        {
            //create the output directory
            CreateDirectories();
            //create smtp for the directory
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;
            smtpClient.PickupDirectoryLocation = OutputDirectory;
            return smtpClient;
        }

        private void PrepareXmlMail()
        {
            //drop folder
            if (Directory.Exists(XmlMailDirectory)) Directory.Delete(XmlMailDirectory, true);
            //create the output directory
            CreateDirectories();
            //add in single email - WILL FAIL IF Create Fails
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var item = ms.Create(GetEmail("one"));
            item = ms.Create(GetEmail("two"));
            item = ms.Create(GetEmail("three"));
        }

    }
}
