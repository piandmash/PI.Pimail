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
using System.IO;
using System.Xml.Serialization;

using PI.Pimail.Models;

namespace PI.Pimail
{
    /// <markdown>
    /// #PI.Pimail.Models.MailStoreXml
    /// File: MailStoreXml.cs
    /// </markdown>
    /// <summary>
    /// Xml backed mail store using the IMailStore interface
    /// </summary>
    public class MailStoreXml : IMailStore
    {

        #region Properties

        /// <markdown>
        /// ### private string Folder = ""
        /// </markdown>
        /// <summary>
        /// Sets the default folder for the Xml to be saved to
        /// </summary>
        private string Folder = "";

        #endregion


        #region Constuctors

        /// <markdown>
        /// ###public MailStoreDatabase()
        /// </markdown>
        /// <summary>
        /// Default empty constructor as used in live requests
        /// </summary>
        public MailStoreXml()
        {
        }
        
        /// <markdown>
        /// ###public MailStoreDatabase()
        /// </markdown>
        /// <summary>
        /// Constructor with the folder set on creation
        /// </summary>
        /// <param name="folder">The folder value to set</param>
        public MailStoreXml(string folder)
        {
            Folder = folder;
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
            var list = new List<Email>();
            if (Directory.Exists(Folder))
            {
                DirectoryInfo dir = new DirectoryInfo(Folder);
                foreach (FileInfo file in dir.GetFiles())
                {
                    list.Add(new Email
                    {
                        Name = file.Name,
                        Updated = file.LastWriteTimeUtc,
                        Created = file.CreationTimeUtc                       
                    });
                }
            }
            return list.AsQueryable();
        }

        /// <markdown>
        /// ###public Email FindByName(string name)
        /// </markdown>
        /// <summary>
        /// Finds the object by name from the list
        /// </summary>
        /// <param name="name">The name to search on</param>
        /// <returns>Always returns null as the string name is embeded within the Xml files and not in the FileInfo</returns>
        public Email FindByName(string name)
        {
            return null;
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
            Email email = null;
            try
            {
                string path = Folder + @"\" + id + ".xml";
                if (!File.Exists(path)) return null;
                XmlSerializer serializer = new XmlSerializer(typeof(Email));
                StreamReader reader = new StreamReader(path);
                email = (Email)serializer.Deserialize(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return email
            return email;
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
                string path = Folder + @"\" + email.Id + ".xml";
                if (File.Exists(path)) throw new DuplicateNameException("Email " + email.Name + " already exists");
                XmlSerializer serializer = new XmlSerializer(typeof(Email));
                StreamWriter file = new StreamWriter(path, false);
                serializer.Serialize(file, email);
                file.Close();
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
                string path = Folder + @"\" + email.Id + ".xml";
                if (File.Exists(path)) throw new DuplicateNameException("Email " + email.Name + " already exists");
                XmlSerializer serializer = new XmlSerializer(typeof(Email));
                StreamWriter file = new StreamWriter(path, false);
                serializer.Serialize(file, email);
                file.Close();
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
                string path = Folder + @"\" + email.Id + ".xml";
                XmlSerializer serializer = new XmlSerializer(typeof(Email));
                StreamWriter file = new StreamWriter(path, false);
                serializer.Serialize(file, email);
                file.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return email
            return email;
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
                string path = Folder + @"\" + email.Id + ".xml";
                XmlSerializer serializer = new XmlSerializer(typeof(Email));
                StreamWriter file = new StreamWriter(path, false);
                serializer.Serialize(file, email);
                file.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //return email
            return email;
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

        //MIGHT DROP THIS?
        /// <markdown>
        /// ###public IQueryable<FileInfo> FileInfoList()
        /// </markdown>
        /// <summary>
        /// A Queryable list of emails based on FileInfo
        /// </summary>
        public IQueryable<FileInfo> FileInfoList()
        {
            var list = new List<FileInfo>();
            if (Directory.Exists(Folder))
            {
                DirectoryInfo dir = new DirectoryInfo(Folder);
                foreach (FileInfo file in dir.GetFiles())
                {
                    list.Add(file);
                }
            }
            return list.AsQueryable();
        }

        #endregion
    }
}
