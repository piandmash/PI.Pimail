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
        public void Pimail_MailStoreDatabase_List_ShouldReturnAllEmails()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail("one"));
            context.Emails.Add(GetEmail("two"));
            context.Emails.Add(GetEmail("three"));

            //Act
            IMailStore ms = new MailStoreDatabase(context);
            var items = ms.List();

            //Assert
            Assert.AreEqual(3, items.Count());
            
        }


        [TestMethod]
        public void Pimail_MailStoreDatabase_FindByName_ShouldReturnFoundMail()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail("one"));
            context.Emails.Add(GetEmail("two"));
            context.Emails.Add(GetEmail("three"));

            //Act
            IMailStore ms = new MailStoreDatabase(context);
            var item = ms.FindByName("one");

            //Assert
            Assert.AreEqual("one", item.Name);

        }

        [TestMethod]
        public void Pimail_MailStoreDatabase_FindByName_ShouldFail_NoMail()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail("one"));
            context.Emails.Add(GetEmail("two"));
            context.Emails.Add(GetEmail("three"));

            //Act
            IMailStore ms = new MailStoreDatabase(context);
            var item = ms.FindByName("four");

            //Assert
            Assert.IsNull(item);

        }


        [TestMethod]
        public void Pimail_MailStoreDatabase_Create_ShouldReturnNewMail()
        {
            //Arrange
            var context = new TestPimailContext();
            Email email = GetEmail();

            //Act
            IMailStore ms = new MailStoreDatabase(context);
            var item = ms.Create(email);

            //Assert
            Assert.AreEqual(email.Name, item.Name);
        }


        [TestMethod]
        public async void Pimail_MailStoreDatabase_CreateAsync_ShouldReturnNewMail()
        {
            //Arrange
            var context = new TestPimailContext();
            Email email = GetEmail();

            //Act
            IMailStore ms = new MailStoreDatabase(context);
            var item = await ms.CreateAsync(email);

            //Assert
            Assert.AreEqual(email.Name, item.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateNameException))]
        public void Pimail_MailStoreDatabase_Create_ShouldFail_MailExists()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail());
            Email email = GetEmail();

            //Act
            IMailStore ms = new MailStoreDatabase(context);
            var item = ms.Create(email);

        }

        [TestMethod]
        public void Pimail_MailStoreDatabase_Update_ShouldReturnSavedMail()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail());
            Email email = GetEmail();
            email.To = "hi@test.com";
            email.SetUpdate("Bob");

            //Act
            IMailStore ms = new MailStoreDatabase(context);
            var item = ms.Update(email);

            //Assert
            Assert.AreEqual("hi@test.com", item.To);
            Assert.AreEqual("Bob", item.Updator);
        }

        [TestMethod]
        public async void Pimail_MailStoreDatabase_UpdateAsync_ShouldReturnSavedMail()
        {
            //Arrange
            var context = new TestPimailContext();
            context.Emails.Add(GetEmail());
            Email email = GetEmail();
            email.To = "hi@test.com";
            email.SetUpdate("Bob");

            //Act
            IMailStore ms = new MailStoreDatabase(context);
            var item = await ms.UpdateAsync(email);

            //Assert
            Assert.AreEqual("hi@test.com", item.To);
            Assert.AreEqual("Bob", item.Updator);
        }
    }
}
