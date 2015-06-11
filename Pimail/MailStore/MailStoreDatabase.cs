using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

using PI.Pimail.Models;

namespace PI.Pimail
{
    /// <markdown>
    /// #PI.Pimail.Models.MailStoreDatabase
    /// File: MailStoreDatabase.cs
    /// </markdown>
    /// <summary>
    /// Databased backed mail store using the IMailStore interface
    /// </summary>
    public class MailStoreDatabase : IMailStore
    {
        #region Properties

        /// <markdown>
        /// ###private IPimailContext db = new PimailContext()
        /// </markdown>
        /// <summary>
        /// Sets the default IPimailContext to be used
        /// </summary>
        private IPimailContext db = new PimailContext();

        #endregion

        #region Constuctors

        /// <markdown>
        /// ###public MailStoreDatabase()
        /// </markdown>
        /// <summary>
        /// Default empty constructor as used in live requests
        /// </summary>
        public MailStoreDatabase()
        {
        }

        // Constructors allow for context to be set for testing
        /// <markdown>
        /// ###public MailStoreDatabase()
        /// </markdown>
        /// <summary>
        /// Constructors allow for context to be set for testing
        /// </summary>
        /// <param name="context">The IPimailContext to use for the store</param>
        public MailStoreDatabase(IPimailContext context)
        {
            db = context;
        }

        #endregion

        #region Methods IMailStore

        /// <markdown>
        /// ###public IQueryable<Email> List()
        /// </markdown>
        /// <summary>
        /// A Queryable list of emails
        /// </summary>
        public IQueryable<Email> List()
        {
            return db.Emails;
        }

        /// <markdown>
        /// ###public Email FindByName(string name)
        /// </markdown>
        /// <summary>
        /// Finds the object by name from the list
        /// </summary>
        /// <param name="name">The name to search on</param>
        /// <returns>A matching email or null</returns>
        public Email FindByName(string name)
        {
            return db.Emails.Select(e => e).Where(e => e.Name == name).FirstOrDefault();
        }

        /// <markdown>
        /// ###public Email Find(string id)
        /// </markdown>
        /// <summary>
        /// Finds the object by id from the list
        /// </summary>
        /// <param name="id">The id to search on</param>
        /// <returns>A matching email or null</returns>
        public Email Find(string id)
        {
            return db.Emails.Select(e => e).Where(e => e.Id == id).FirstOrDefault();
        }

        /// <markdown>
        /// ###public Email Create(Email email)
        /// </markdown>
        /// <summary>
        /// Creates the email within the data store
        /// </summary>
        /// <param name="email">The email to create</param>
        /// <returns>The created email</returns>
        public Email Create(Email email)
        {
            try
            {
                Email saved = Find(email.Id);
                if (saved != null)
                {
                    throw new DuplicateNameException("Email " + email.Name + " already exists");
                }
                //add email
                db.Emails.Add(email);
                //save
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return email
            return email;
        }

        /// <markdown>
        /// ###public Task[Email] CreateAsync(Email email)
        /// </markdown>
        /// <summary>
        /// Asynchronously creates the email within the data store
        /// </summary>
        /// <param name="email">The email to create</param>
        /// <returns>The created email</returns>
        public async Task<Email> CreateAsync(Email email)
        {
            try
            {
                Email saved = Find(email.Id);
                if (saved != null)
                {
                    throw new DuplicateNameException("Email " + email.Name + " already exists");
                }
                //add email
                db.Emails.Add(email);
                //await for async save
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return email
            return email;
        }

        /// <markdown>
        /// ###public Email Update(Email email)
        /// </markdown>
        /// <summary>
        /// Updates the email within the data store
        /// </summary>
        /// <param name="email">The email to update</param>
        /// <returns>The updated email</returns>
        public Email Update(Email email)
        {
            try
            {
                //find email
                Email saved = Find(email.Id);
                if (saved == null)
                {
                    throw new NullReferenceException("No email found");
                }
                CopyEmail(saved, email);
                //mark as modified
                db.MarkAsModified(saved);
                //save
                db.SaveChanges();
                //return email
                return saved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <markdown>
        /// ###Task[Email] UpdateAsync(Email email)
        /// </markdown>
        /// <summary>
        /// Asynchronously updates the email within the data store
        /// </summary>
        /// <param name="email">The email to update</param>
        /// <returns>The updated email</returns>
        public async Task<Email> UpdateAsync(Email email)
        {
            try
            {
                //find email
                Email saved = Find(email.Id);
                if (saved == null)
                {
                    throw new NullReferenceException("No email found");
                }
                CopyEmail(saved, email);
                //mark as modified
                db.MarkAsModified(saved);
                //save
                await db.SaveChangesAsync();
                //return email
                return saved;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Methods 
        
        /// <markdown>
        /// ###Task[Email] UpdateAsync(Email email)
        /// </markdown>
        /// <summary>
        /// Applies the copy email properties onto the original email
        /// </summary>
        /// <param name="original">The original email to populate</param>
        /// <param name="copy">The email to copy</param>
        private void CopyEmail( Email original, Email copy)
        {

            //update
            original.Name = copy.Name;
            original.AdditionalHeaders = copy.AdditionalHeaders;
            original.Archived = copy.Archived;
            original.Bcc = copy.Bcc;
            original.BodyHtml = copy.BodyHtml;
            original.BodyPlain = copy.BodyPlain;
            original.Cc = copy.Cc;
            original.ContentEncoding = copy.ContentEncoding;
            original.Created = copy.Created;
            original.Creator = copy.Creator;
            original.Deleted = copy.Deleted;
            original.FilesToAttach = copy.FilesToAttach;
            original.From = copy.From;
            original.FromDisplay = copy.FromDisplay;
            original.HeaderEncoding = copy.HeaderEncoding;
            original.IsBodyHtml = copy.IsBodyHtml;
            original.Priority = copy.Priority;
            original.ReplyTo = copy.ReplyTo;
            original.Subject = copy.Subject;
            original.To = copy.To;
            original.Updated = copy.Updated;
            original.Updator = copy.Updator;
        }
        #endregion
    }
}
