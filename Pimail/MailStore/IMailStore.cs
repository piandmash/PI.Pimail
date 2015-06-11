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
    /// #PI.Pimail.Models.IMailStore
    /// File: IMailStore.cs
    /// </markdown>
    /// <summary>
    /// Interface for a mail store
    /// </summary>
    public interface IMailStore
    {
        #region Methods

        /// <markdown>
        /// ###IQueryable<Email> List()
        /// </markdown>
        /// <summary>
        /// A Queryable list of emails
        /// </summary>
        IQueryable<Email> List();

        /// <markdown>
        /// ###Email FindByName(string name)
        /// </markdown>
        /// <summary>
        /// Finds the object by name from the list
        /// </summary>
        /// <param name="name">The name to search on</param>
        /// <returns>A matching email or null</returns>
        Email FindByName(string name);

        /// <markdown>
        /// ###Email Find(string id)
        /// </markdown>
        /// <summary>
        /// Finds the object by id from the list
        /// </summary>
        /// <param name="id">The id to search on</param>
        /// <returns>A matching email or null</returns>
        Email Find(string id);

        /// <markdown>
        /// ###Email Create(Email email)
        /// </markdown>
        /// <summary>
        /// Creates the email within the data store
        /// </summary>
        /// <param name="email">The email to create</param>
        /// <returns>The created email</returns>
        Email Create(Email email);


        /// <markdown>
        /// ###Task[Email] CreateAsync(Email email)
        /// </markdown>
        /// <summary>
        /// Asynchronously creates the email within the data store
        /// </summary>
        /// <param name="email">The email to create</param>
        /// <returns>The created email</returns>
        Task<Email> CreateAsync(Email email);


        /// <markdown>
        /// ###Email Update(Email email)
        /// </markdown>
        /// <summary>
        /// Updates the email within the data store
        /// </summary>
        /// <param name="email">The email to update</param>
        /// <returns>The updated email</returns>
        Email Update(Email email);

        /// <markdown>
        /// ###Task[Email] UpdateAsync(Email email)
        /// </markdown>
        /// <summary>
        /// Asynchronously updates the email within the data store
        /// </summary>
        /// <param name="email">The email to update</param>
        /// <returns>The updated email</returns>
        Task<Email> UpdateAsync(Email email);

        #endregion
    }
}
