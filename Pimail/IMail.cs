using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;

using PI.Pimail.Models;

namespace PI.Pimail
{
    /// <markdown>
    /// #PI.Pimail.IMail
    /// File: IMail.cs
    /// </markdown>
    /// <summary>
    /// Interface for a mail object
    /// </summary>
    public interface IMail
    {
        #region Properties

        /// <markdown>
        /// ###string TagStart
        /// </markdown>
        /// <summary>
        /// The start tag used as a placeholder
        /// </summary>
        string TagStart { get; set; }

        /// <markdown>
        /// ###string TagEnd
        /// </markdown>
        /// <summary>
        /// The end tag used as a placeholder
        /// </summary>
        string TagEnd { get; set; }

        /// <markdown>
        /// ###string FileRoot
        /// </markdown>
        /// <summary>
        /// The root folder for any file attachments
        /// </summary>
        string FileRoot { get; set; }

        #endregion

        #region Methods
        /// <markdown>
        /// ###void Add(object key, object value)
        /// </markdown>
        /// <summary>
        /// Adds a key and it's value to the Hash Table
        /// </summary>
        /// <param name="key">The Hash Table key</param>
        /// <param name="value">The object to to be stored</param>
        void Add(object key, object value);

        /// <markdown>
        /// ###void Remove(object key)
        /// </markdown>
        /// <summary>
        /// Removes a key pair from the hash table
        /// </summary>
        /// <param name="key">Key to remove</param>
        void Remove(object key);

        /// <markdown>
        /// ###void Clear()
        /// </markdown>
        /// <summary>
        /// Clears the hash table
        /// </summary>
        void Clear();

        /// <markdown>
        /// ###void AddObject(object itemToAdd, string prefix = "")
        /// </markdown>
        /// <summary>
        /// Adds in bulk object properties to an email.
        /// The prefix should be added to the email parameters
        /// in the xml email body
        /// e.g. [PRIZE_DISPLAYNAME] where prefix is "PRIZE_"
        /// </summary>
        /// <param name="itemToAdd">The item to add to mail</param>
        /// <param name="prefix">The parameters are prefixed with this to avoid duplicate addding of values such as id</param>
        void AddObject(object itemToAdd, string prefix = "");



        /// <markdown>
        /// ### MailMessage BuildMailMessage(Email email)
        /// </markdown>
        /// <summary>
        /// Builds a mail message from the email object sent with the hash table values replaced
        /// </summary>
        /// <param name="email">The email to create the mail message from</param>
        /// <returns>New MailMessage</returns>
        MailMessage BuildMailMessage(Email email);

        #endregion
    }
}
