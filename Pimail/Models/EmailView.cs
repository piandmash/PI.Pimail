using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;

using PI.Pimail.Resources;

namespace PI.Pimail.Models
{
    
    /// <markdown>
    /// #PI.Pimail.Models.EmailView
    /// File: EmailView.cs
    /// </markdown>
    /// <summary>
    /// A View class showing the required email properties to send and build an email
    /// </summary>
    public partial class EmailView
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
        /// * [Required]
        /// * [MaxLength(128)]
        /// * [MaxLength(3)]
        /// </markdown>
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
        public EmailView()
        {
            this.IsBodyHtml = true;
            this.ContentEncoding = "utf-8";
            this.HeaderEncoding = "utf-8";
            this.Priority = MailPriority.Normal;
        }

        /// <markdown>
        /// ###public Email(Email email)
        /// </markdown>
        /// <summary>
        /// Constructor for the class that populates the view from the email sent
        /// </summary>
        /// <param name="email">The email to populate the view with</param>
        public EmailView(Email email)
            : this()
        {
            Populate(email);
        }

        #endregion

        #region Methods

        /// <markdown>
        /// ###public virtual Email Create(string userName = "Anonymous")
        /// </markdown>
        /// <summary>
        /// Creates an email from the view data
        /// </summary>
        /// <param name="userName">The user name of the creator</param>
        /// <returns>An Email model</returns>
        public virtual Email Create(string userName = "Anonymous")
        {
            Email email = new Email()
            {
                Id = this.Id,
                Name = this.Name,
                Subject = this.Subject,
                To = this.To,
                From = this.From,
                FromDisplay = this.FromDisplay,
                Cc = this.Cc,
                Bcc = this.Bcc,
                ReplyTo = this.ReplyTo,
                ContentEncoding = this.ContentEncoding,
                HeaderEncoding = this.HeaderEncoding,
                AdditionalHeaders = this.AdditionalHeaders,
                IsBodyHtml = this.IsBodyHtml,
                Priority = this.Priority
            };
            //set id
            email.Id = email.StringToId(email.Name);
            //set the creator and updator
            email.SetCreate(userName);
            //return the created email
            return email;
        }

        /// <markdown>
        /// ###public virtual void Update(Email email)
        /// </markdown>
        /// <summary>
        /// Updates an Email from the view data
        /// </summary>
        /// <param name="email">The Email to update</param>
        public virtual void Update(Email email)
        {
            email.Id = this.Id;
            email.Name = this.Name;
            email.Subject = this.Subject;
            email.To = this.To;
            email.From = this.From;
            email.FromDisplay = this.FromDisplay;
            email.Cc = this.Cc;
            email.Bcc = this.Bcc;
            email.ReplyTo = this.ReplyTo;
            email.ContentEncoding = this.ContentEncoding;
            email.HeaderEncoding = this.HeaderEncoding;
            email.AdditionalHeaders = this.AdditionalHeaders;
            email.IsBodyHtml = this.IsBodyHtml;
            email.Priority = this.Priority;
        }

        /// <markdown>
        /// ###public virtual void Populate(Email email)
        /// </markdown>
        /// <summary>
        /// Updates an Email from the view data
        /// </summary>
        /// <param name="email">The Email to update</param>
        public virtual void Populate(Email email)
        {
            this.Id = email.Id;
            this.Name = email.Name;
            this.Subject = email.Subject;
            this.To = email.To;
            this.From = email.From;
            this.FromDisplay = email.FromDisplay;
            this.Cc = email.Cc;
            this.Bcc = email.Bcc;
            this.ReplyTo = email.ReplyTo;
            this.ContentEncoding = email.ContentEncoding;
            this.HeaderEncoding = email.HeaderEncoding;
            this.AdditionalHeaders = email.AdditionalHeaders;
            this.IsBodyHtml = email.IsBodyHtml;
            this.Priority = email.Priority;
        }

        #endregion
    }


    /// <markdown>
    /// #PI.Pimail.Models.EmailFullView
    /// File: EmailView.cs
    /// </markdown>
    /// <summary>
    /// A View class showing the entire email, inherits from EmailView
    /// </summary>
    public partial class EmailFullView : EmailView
    {

        #region Properties

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
        /// ###public List<string> FilesToAttach
        /// </markdown>
        /// <summary>
        /// Gets/sets a list of fiels to attach
        /// </summary>
        public List<string> FilesToAttach { get; set; }

        #endregion

        #region Constructors

        /// <markdown>
        /// ###public EmailFullView()
        /// </markdown>
        /// <summary>
        /// Default constructor for the class setting:
        /// * IsBodyHtml = true;
        /// * ContentEncoding = "utf-8";
        /// * HeaderEncoding = "utf-8";
        /// * Priority = MailPriority.Normal
        /// </summary>
        public EmailFullView()
            : base()
        {
            this.FilesToAttach = new List<string>();
        }

        /// <markdown>
        /// ###public EmailFullView(Email email)
        /// </markdown>
        /// <summary>
        /// Constructor for the class that populates the view from the email sent
        /// </summary>
        /// <param name="email">The email to populate the view with</param>
        public EmailFullView(Email email)
            : this()
        {
            Populate(email);
        }
        #endregion

        #region Methods

        /// <markdown>
        /// ###public override Email Create(string userName = "Anonymous")
        /// </markdown>
        /// <summary>
        /// Creates an email from the view data
        /// </summary>
        /// <param name="userName">The user name of the creator</param>
        /// <returns>An Email model</returns>
        public override Email Create(string userName = "Anonymous")
        {
            Email email = base.Create(userName);
            email.FilesToAttach = this.FilesToAttach;
            email.BodyHtml = System.Web.HttpUtility.HtmlDecode(this.BodyHtml);
            email.BodyPlain = this.BodyPlain;
            //return the created email
            return email;
        }

        /// <markdown>
        /// ###public override void Update(Email email)
        /// </markdown>
        /// <summary>
        /// Updates an Email from the view data
        /// </summary>
        /// <param name="email">The Email to update</param>
        public override void Update(Email email)
        {
            base.Update(email);
            email.FilesToAttach = this.FilesToAttach;
            email.BodyHtml = System.Web.HttpUtility.HtmlDecode(this.BodyHtml);
            email.BodyPlain = this.BodyPlain;
        }

        /// <markdown>
        /// ###public override void Populate(Email email)
        /// </markdown>
        /// <summary>
        /// Updates an Email from the view data
        /// </summary>
        /// <param name="email">The Email to update</param>
        public override void Populate(Email email)
        {
            base.Populate(email);
            this.FilesToAttach = email.FilesToAttach;
            this.BodyHtml = System.Web.HttpUtility.HtmlEncode(email.BodyHtml);
            this.BodyPlain = email.BodyPlain;
        }

        #endregion
    }
};