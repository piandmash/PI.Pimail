using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PI.Pimail.Models
{
    /// <markdown>
    /// #PI.Pimail.Models.PimailContext
    /// File: PimailContext.cs
    /// </markdown>
    /// <summary>
    /// DbContext used in saving the mail object to a database Entity Framework, implementing the IPimailContext
    /// </summary>
    public class PimailContext : DbContext, IPimailContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx


        #region Properties

        /// <markdown>
        /// ###public DbSet<Email> Emails
        /// </markdown>
        /// <summary>
        /// DBSet of emails
        /// </summary>
        public DbSet<Email> Emails { get; set; }
        
        #endregion

        #region Constructors

        /// <markdown>
        /// ###public PimailContext()
        /// </markdown>
        /// <summary>
        /// Default constuctor sets the nameOrConnectionString to PimailContext
        /// Constructs a new context instance using conventions to create the name of
        /// the database to which a connection will be made. The by-convention name is
        /// the full name (namespace + class name) of the derived context class.  See
        /// the class remarks for how this is used to create a connection.
        /// </summary>
        public PimailContext()
            : base("name=PimailContext")
        {
        }

        /// <summary>
        /// Constructs a new context instance using the given string as the name or connection 
        /// string for the database to which a connection will be made.  See the class
        /// remarks for how this is used to create a connection.
        /// </summary>
        /// <param name="nameOrConnectionString">Either the database name or a connection string</param>
        public PimailContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        #endregion

        #region Methods

        //public IQueryable<Email> Emails { get { return DbEmails; } set { DbEmails = (DbSet<Email>)value; } }

        /// <markdown>
        /// ###public void MarkAsModified(object item)
        /// </markdown>
        /// <summary>
        /// Sets the EntityState of the object to Modified
        /// </summary>
        /// <param name="item">The item to update</param>
        public void MarkAsModified(object item)
        {
            Entry(item).State = EntityState.Modified;
        }

        /// <markdown>
        /// ###protected override void OnModelCreating(DbModelBuilder modelBuilder)
        /// </markdown>
        /// <summary>
        /// Override of the OnModelCreating method used to map the entity to stored procedures
        /// </summary>
        /// <param name="modelBuilder">The builder that defines the model for the context being created.</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Email>().MapToStoredProcedures();

            base.OnModelCreating(modelBuilder);
        }

        #endregion
    }
}
