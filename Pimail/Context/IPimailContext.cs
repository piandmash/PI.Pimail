using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading;
using System.Threading.Tasks;

namespace PI.Pimail.Models
{
    //**** Dependency injection for testing see the link below
    //**** http://www.asp.net/web-api/overview/testing-and-debugging/mocking-entity-framework-when-unit-testing-aspnet-web-api-2


    /// <markdown>
    /// #PI.Pimail.Models.IPimailContext
    /// File: IPimailContext.cs
    /// </markdown>
    /// <summary>
    /// Interface for the Context used in saving the mail object to a data store using Entity Framework
    /// </summary>
    public interface IPimailContext : IDisposable
    {

        #region Properties

        /// <markdown>
        /// ###DbSet<Email> Emails
        /// </markdown>
        /// <summary>
        /// DBSet of emails, get only
        /// </summary>
        DbSet<Email> Emails { get; }

        #endregion

        #region Methods

        /// <markdown>
        /// ###int SaveChanges()
        /// </markdown>
        /// <summary>
        /// Saves all changes made in this context to the underlying store.
        /// </summary>
        /// <returns>The number of objects written to the underlying store.</returns>
        int SaveChanges();

        /// <markdown>
        /// ###Task[int] SaveChangesAsync()
        /// </markdown>
        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying store.
        /// </summary>
        /// <returns>A task that represents the asynchronous save operation.  The task result contains the number of objects written to the underlying store.</returns>
        Task<int> SaveChangesAsync();

        /// <markdown>
        /// ###Task[int] SaveChangesAsync(CancellationToken cancellationToken)
        /// </markdown>
        /// <summary>
        /// Asynchronously saves all changes made in this context to the underlying store.
        /// </summary>
        /// <param name="cancellationToken">A System.Threading.CancellationToken to observe while waiting for the task to complete.</param>
        /// <returns>A task that represents the asynchronous save operation.  The task result contains the number of objects written to the underlying store.</returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        

        /// <markdown>
        /// ###void MarkAsModified(object item)
        /// </markdown>
        /// <summary>
        /// Sets the EntityState of the object to Modified
        /// </summary>
        /// <param name="item">The item to update</param>
        void MarkAsModified(object item);

        #endregion
    }
}