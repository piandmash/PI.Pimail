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
using System.Data;

using PI.Pimail;
using PI.Pimail.Models;

namespace PI.Pimail.Tests
{

    public partial class TestPimail
    {

        [TestMethod]
        public void Pimail_MailStoreXml_List_ShouldReturnAllEmails()
        {
            //Arrange
            PrepareXmlMail();

            //Act
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var items = ms.List();

            //Assert
            Assert.AreEqual(3, items.Count());

        }


        [TestMethod]
        public void Pimail_MailStoreXml_FindByName_ShouldReturnFoundMail()
        {
            //Arrange
            PrepareXmlMail();

            //Act
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var item = ms.Find("one");

            //Assert
            Assert.AreEqual("one", item.Name);

        }

        [TestMethod]
        public void Pimail_MailStoreXml_FindByName_ShouldFail_NoMail()
        {
            //Arrange
            PrepareXmlMail();

            //Act
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var item = ms.Find("four");

            //Assert
            Assert.IsNull(item);

        }


        [TestMethod]
        public void Pimail_MailStoreXml_Create_ShouldReturnNewMail()
        {
            //Arrange
            Email email = GetEmail();

            //Act
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var item = ms.Create(email);

            //Assert
            Assert.AreEqual(email.Name, item.Name);
        }


        [TestMethod]
        public async void Pimail_MailStoreXml_CreateAsync_ShouldReturnNewMail()
        {
            //Arrange
            var context = new TestPimailContext();
            Email email = GetEmail();

            //Act
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var item = await ms.CreateAsync(email);

            //Assert
            Assert.AreEqual(email.Name, item.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void Pimail_MailStoreXml_Create_ShouldFail_MailExists()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail());
            Email email = GetEmail();

            //Act
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var item = ms.Create(email);

        }

        [TestMethod]
        public void Pimail_MailStoreXml_Update_ShouldReturnSavedMail()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail());
            Email email = GetEmail();
            email.To = "hi@test.com";
            email.SetUpdate("Bob");

            //Act
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var item = ms.Update(email);

            //Assert
            Assert.AreEqual("hi@test.com", item.To);
            Assert.AreEqual("Bob", item.Updator);
        }

        [TestMethod]
        public async void Pimail_MailStoreXml_UpdateAsync_ShouldReturnSavedMail()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail());
            Email email = GetEmail();
            email.To = "hi@test.com";
            email.SetUpdate("Bob");

            //Act
            IMailStore ms = new MailStoreXml(XmlMailDirectory);
            var item = await ms.UpdateAsync(email);

            //Assert
            Assert.AreEqual("hi@test.com", item.To);
            Assert.AreEqual("Bob", item.Updator);
        }
    }
}
