using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Net.Mime;

using PI.Pimail;
using PI.Pimail.Models;

namespace PI.Pimail.Tests
{
    [TestClass]
    public partial class TestPimail : IDisposable
    {

        [TestMethod]
        public void Pimail_Mail_Add_ShouldAddAKey()
        {
            //Arrange
            IMail mail = new Mail();
            Email email = GetEmail();

            //Act
            mail.Add("NAME", "Pete");
            MailMessage mm = mail.BuildMailMessage(email);

            //Assert
            Assert.AreEqual("Hi Pete", mm.Subject);
        }

        [TestMethod]
        public void Pimail_Mail_Remove_ShouldRemoveKey()
        {
            //Arrange
            IMail mail = new Mail();
            Email email = GetEmail();

            //Act
            mail.Add("NAME", "Pete");
            mail.Remove("NAME");
            MailMessage mm = mail.BuildMailMessage(email);

            //Assert
            Assert.AreEqual("Hi [NAME]", mm.Subject);
        }

        [TestMethod]
        public void Pimail_Mail_AddObject_ShouldAddKeys()
        {
            //Arrange
            IMail mail = new Mail();
            Email email = GetEmail();

            //Act
            mail.AddObject(new { NAME = "Pete" });
            MailMessage mm = mail.BuildMailMessage(email);

            //Assert
            Assert.AreEqual("Hi Pete", mm.Subject);
        }

        [TestMethod]
        public void Pimail_Mail_AddObject_ShouldAddKeysWithIEnumerable()
        {
            //Arrange
            IMail mail = new Mail();
            Email email = GetEmail();

            List<object> names = new List<object>();
            names.Add(new {FirstName = "Tom", LastName = "Smith"});
            names.Add(new {FirstName = "Dick", LastName = "Jones"});
            names.Add(new {FirstName = "Harry", LastName = "Hill"});

            //Act
            mail.AddObject(new { NAME = "Pete", Names = names });
            MailMessage mm = mail.BuildMailMessage(email);

            //Assert
            Assert.AreEqual("Hi Pete", mm.Subject);
            Assert.AreEqual("<h1>Hi Pete</h1><p>How are you? [SUB_NAME]</p><ul><li>Tom Smith</li><li>Dick Jones</li><li>Harry Hill</li></ul>", mm.Body);
        }

        [TestMethod]
        public void Pimail_Mail_Send_ShouldWork()
        {
            //Arrange
            IMail mail = new Mail();
            Email email = GetEmail();

            //Act
            mail.AddObject(new { NAME = "Pete" });
            MailMessage mm = mail.BuildMailMessage(email);
            SmtpClient smtp = GetSmtpClient();
            smtp.Send(mm);

            //Assert
            Assert.AreEqual("Hi Pete", mm.Subject);
        }

        public void Dispose()
        {
            CleanOutput();
        }
    }
}
