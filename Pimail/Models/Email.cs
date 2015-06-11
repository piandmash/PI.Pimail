using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.IO;

using PI.Pimail.Resources;

namespace PI.Pimail.Models
{

    /// <markdown>
    /// #PI.Pimail.Models.Email
    /// File: Email.cs
    /// </markdown>
    /// <summary>
    /// The Email Data Layer class, inherits the BaseClass
    /// </summary>
    public partial class Email : BaseClass
    {

        #region Properties

        /// <markdown>
        /// ###public string Id
        /// </markdown>
        /// <summary>
        /// Gets/sets the id
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Key]
        /// * [Required]
        /// * [MaxLength(128)]
        /// * [MaxLength(3)]
        /// </markdown>
        [Key]
        [Required(
            ErrorMessageResourceName = "Id_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        [MaxLength(
            128,
            ErrorMessageResourceName = "Id_MaxLength_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        [MinLength(
            3,
            ErrorMessageResourceName = "Id_MinLength_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string Id { get; set; }

        /// <markdown>
        /// ###public string Name
        /// </markdown>
        /// <summary>
        /// Gets/sets the email name
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// * [MaxLength(128)]
        /// * [MaxLength(3)]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "Name_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        [MaxLength(
            128,
            ErrorMessageResourceName = "Name_MaxLength_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        [MinLength(
            3,
            ErrorMessageResourceName = "Name_MinLength_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string Name { get; set; }

        /// <markdown>
        /// ###public string To
        /// </markdown>
        /// <summary>
        /// Gets/sets the email To
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// * [MaxLength(3)]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "To_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        [MinLength(
            3,
            ErrorMessageResourceName = "To_MinLength_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string To { get; set; }

        /// <markdown>
        /// ###public string Subject
        /// </markdown>
        /// <summary>
        /// Gets/sets the email Subject
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// * [MaxLength(128)]
        /// * [MaxLength(3)]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "Subject_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        [MaxLength(
            128,
            ErrorMessageResourceName = "Subject_MaxLength_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        [MinLength(
            3,
            ErrorMessageResourceName = "Subject_MinLength_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string Subject { get; set; }

        /// <markdown>
        /// ###public string BodyHtml
        /// </markdown>
        /// <summary>
        /// Gets/sets the email body html value
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "BodyHtml_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string BodyHtml { get; set; }

        /// <markdown>
        /// ###public string BodyPlain
        /// </markdown>
        /// <summary>
        /// Gets/sets the email body plain text value
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "BodyPlain_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string BodyPlain { get; set; }

        /// <markdown>
        /// ###public string From
        /// </markdown>
        /// <summary>
        /// Gets/sets the email from
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "From_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string From { get; set; }

        /// <markdown>
        /// ###public string FromDisplay
        /// </markdown>
        /// <summary>
        /// Gets/sets the email from display text
        /// </summary>
        public string FromDisplay { get; set; }

        /// <markdown>
        /// ###public string Cc
        /// </markdown>
        /// <summary>
        /// Gets/sets the email Cc addresses
        /// </summary>
        public string Cc { get; set; }

        /// <markdown>
        /// ###public List<string> FilesToAttach
        /// </markdown>
        /// <summary>
        /// Gets/sets a list of fiels to attach
        /// </summary>
        public List<string> FilesToAttach { get; set; }

        /// <markdown>
        /// ###public bool IsBodyHtml
        /// </markdown>
        /// <summary>
        /// Gets/sets if the body is HTML
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "IsBodyHtml_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public bool IsBodyHtml { get; set; }

        /// <markdown>
        /// ###public bool AdditionalHeaders
        /// </markdown>
        /// <summary>
        /// Gets/sets if the additional headers for the email
        /// </summary>
        public string AdditionalHeaders { get; set; }

        /// <markdown>
        /// ###public string Bcc
        /// </markdown>
        /// <summary>
        /// Gets/sets the email Bcc addresses
        /// </summary>
        public string Bcc { get; set; }

        /// <markdown>
        /// ###public string ContentEncoding
        /// </markdown>
        /// <summary>
        /// Gets/sets if the content encoding type
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "ContentEncoding_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string ContentEncoding { get; set; }

        /// <markdown>
        /// ###public string HeaderEncoding
        /// </markdown>
        /// <summary>
        /// Gets/sets if the email header encoding type
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "HeaderEncoding_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public string HeaderEncoding { get; set; }

        /// <markdown>
        /// ###public System.Net.Mail.MailPriority Priority
        /// </markdown>
        /// <summary>
        /// Gets/sets if the email Priority
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        [Required(
            ErrorMessageResourceName = "Priority_Required_Error",
            ErrorMessageResourceType = typeof(EmailResource))]
        public System.Net.Mail.MailPriority Priority { get; set; }

        /// <markdown>
        /// ###public string ReplyTo
        /// </markdown>
        /// <summary>
        /// Gets/sets if the email reply to value
        /// </summary>
        /// <markdown>
        /// Attributes
        /// * [Required]
        /// </markdown>
        public string ReplyTo { get; set; }

        #endregion

        #region Constructors

        /// <markdown>
        /// ###public Email()
        /// </markdown>
        /// <summary>
        /// Default constructor for the class setting:
        /// * IsBodyHtml = true;
        /// * ContentEncoding = "utf-8";
        /// * HeaderEncoding = "utf-8";
        /// * Priority = MailPriority.Normal
        /// </summary>
        public Email()
            : base()
        {
            this.IsBodyHtml = true;
            this.ContentEncoding = "utf-8";
            this.HeaderEncoding = "utf-8";
            this.Priority = MailPriority.Normal;
            this.FilesToAttach = new List<string>();
        }

        #endregion
    }
}