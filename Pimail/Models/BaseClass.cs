using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace PI.Pimail.Models
{
    /// <markdown>
    /// #PI.Pimail.Models.BaseClass
    /// File: BaseClass.cs
    /// </markdown>
    /// <summary>
    /// The BaseClass for all objects
    /// </summary>
    public partial class BaseClass
    {

        #region Properties

        /// <markdown>
        /// ###public bool Deleted
        /// </markdown>
        /// <summary>
        /// Gets/sets the object deleted status
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required]
        public bool Deleted { get; set; }

        /// <markdown>
        /// ###public bool Archived
        /// </markdown>
        /// <summary>
        /// Gets/sets the object archived status
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required]
        public bool Archived { get; set; }

        /// <markdown>
        /// ###public string Creator
        /// </markdown>
        /// <summary>
        /// Gets/sets the object creator
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// * [StringLength(256)]
        /// </markdown>
        [Required]
        [StringLength(256)]
        public string Creator { get; set; }

        /// <markdown>
        /// ###public DateTime Created
        /// </markdown>
        /// <summary>
        /// Gets/sets the created date
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required]
        public DateTime Created { get; set; }

        /// <markdown>
        /// ###public string Updator
        /// </markdown>
        /// <summary>
        /// Gets/sets the last updator of the object
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// * [StringLength(256)]
        /// </markdown>
        [Required]
        [StringLength(256)]
        public string Updator { get; set; }

        /// <markdown>
        /// ###public DateTime Created
        /// </markdown>
        /// <summary>
        /// Gets/sets the last updated date
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required]
        public DateTime Updated { get; set; }

        #endregion

        #region Constructors

        /// <markdown>
        /// ###public BaseClass()
        /// </markdown>
        /// <summary>
        /// Default constructor for the class
        /// </summary>
        public BaseClass()
        {
            this.Deleted = false;
            this.Archived = false;
            this.SetCreate("Anonymous");
        }
        #endregion

        #region Methods

        /// <markdown>
        /// ###public string StringToId(string value)
        /// </markdown>
        /// <summary>
        /// Cleans a string to make it suitable for an id
        /// </summary>
        /// <param name="value">The value to clean</param>
        /// <returns>The cleaned value</returns>
        public string StringToId(string value)
        {
            return Regex.Replace(value, @"[^A-Za-z0-9_\.~]+", "-").ToLower();
        }

        /// <markdown>
        /// ###public void SetCreate(string userName)
        /// </markdown>
        /// <summary>
        /// Sets the updator and updated date based on the application user
        /// </summary>
        /// <param name="userName">The user name</param>
        public void SetCreate(string userName)
        {
            this.Creator = userName;
            this.Created = DateTime.UtcNow;
            this.Updator = userName;
            this.Updated = DateTime.UtcNow;
        }

        /// <markdown>
        /// ###public void SetUpdate(string userName)
        /// </markdown>
        /// <summary>
        /// Sets the updator and updated date based on the application user
        /// </summary>
        /// <param name="userName">The user name</param>
        public void SetUpdate(string userName)
        {
            this.Updator = userName;
            this.Updated = DateTime.UtcNow;
        }

        #endregion
    }
}