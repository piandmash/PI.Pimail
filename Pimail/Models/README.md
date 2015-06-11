

#PI.Pimail.Models.BaseClass

File: BaseClass.cs





The BaseClass for all objects



##Properties



###public bool Deleted





Gets/sets the object deleted status





Attributes

* [Required]





###public bool Archived





Gets/sets the object archived status





Attributes

* [Required]





###public string Creator





Gets/sets the object creator





Attributes

* [Required]

* [StringLength(256)]





###public DateTime Created





Gets/sets the created date





Attributes

* [Required]





###public string Updator





Gets/sets the last updator of the object





Attributes

* [Required]

* [StringLength(256)]





###public DateTime Created





Gets/sets the last updated date





Attributes

* [Required]



##Constructors



###public BaseClass()





Default constructor for the class



##Methods



###public string StringToId(string value)





Cleans a string to make it suitable for an id



* value: The value to clean

Returns: The cleaned value



###public void SetCreate(string userName)





Sets the updator and updated date based on the application user



* userName: The user name



###public void SetUpdate(string userName)





Sets the updator and updated date based on the application user



* userName: The user name



#PI.Pimail.Models.Email

File: Email.cs





The Email Data Layer class, inherits the BaseClass



##Properties



###public string Id





Gets/sets the id





Attributes

* [Key]

* [Required]

* [MaxLength(128)]

* [MaxLength(3)]





###public string Name





Gets/sets the email name





Attributes

* [Required]

* [MaxLength(128)]

* [MaxLength(3)]





###public string To





Gets/sets the email To





Attributes

* [Required]

* [MaxLength(3)]





###public string Subject





Gets/sets the email Subject





Attributes

* [Required]

* [MaxLength(128)]

* [MaxLength(3)]





###public string BodyHtml





Gets/sets the email body html value





Attributes

* [Required]





###public string BodyPlain





Gets/sets the email body plain text value





Attributes

* [Required]





###public string From





Gets/sets the email from





Attributes

* [Required]





###public string FromDisplay





Gets/sets the email from display text





###public string Cc





Gets/sets the email Cc addresses





###public List FilesToAttach





Gets/sets a list of fiels to attach





###public bool IsBodyHtml





Gets/sets if the body is HTML





Attributes

* [Required]





###public bool AdditionalHeaders





Gets/sets if the additional headers for the email





###public string Bcc





Gets/sets the email Bcc addresses





###public string ContentEncoding





Gets/sets if the content encoding type





Attributes

* [Required]





###public string HeaderEncoding





Gets/sets if the email header encoding type





Attributes

* [Required]





###public System.Net.Mail.MailPriority Priority





Gets/sets if the email Priority





Attributes

* [Required]





###public string ReplyTo





Gets/sets if the email reply to value





Attributes

* [Required]



##Constructors



###public Email()





Default constructor for the class setting:

* IsBodyHtml = true;

* ContentEncoding = "utf-8";

* HeaderEncoding = "utf-8";

* Priority = MailPriority.Normal





#PI.Pimail.Models.EmailView

File: EmailView.cs





A View class showing the required email properties to send and build an email



##Properties



###public string Id





Gets/sets the id





Attributes

* [Required]

* [MaxLength(128)]

* [MaxLength(3)]





###public string Name





Gets/sets the email name





Attributes

* [Required]

* [MaxLength(128)]

* [MaxLength(3)]





###public string To





Gets/sets the email To





Attributes

* [Required]

* [MaxLength(3)]





###public string Subject





Gets/sets the email Subject





Attributes

* [Required]

* [MaxLength(128)]

* [MaxLength(3)]





###public string From





Gets/sets the email from





Attributes

* [Required]





###public string FromDisplay





Gets/sets the email from display text





###public string Cc





Gets/sets the email Cc addresses





###public bool IsBodyHtml





Gets/sets if the body is HTML





Attributes

* [Required]





###public bool AdditionalHeaders





Gets/sets if the additional headers for the email





###public string Bcc





Gets/sets the email Bcc addresses





###public string ContentEncoding





Gets/sets if the content encoding type





Attributes

* [Required]





###public string HeaderEncoding





Gets/sets if the email header encoding type





Attributes

* [Required]





###public System.Net.Mail.MailPriority Priority





Gets/sets if the email Priority





Attributes

* [Required]





###public string ReplyTo





Gets/sets if the email reply to value





Attributes

* [Required]



##Constructors



###public Email()





Default constructor for the class setting:

* IsBodyHtml = true;

* ContentEncoding = "utf-8";

* HeaderEncoding = "utf-8";

* Priority = MailPriority.Normal





###public Email(Email email)





Constructor for the class that populates the view from the email sent



* email: The email to populate the view with

##Methods



###public virtual Email Create(string userName = "Anonymous")





Creates an email from the view data



* userName: The user name of the creator

Returns: An Email model



###public virtual void Update(Email email)





Updates an Email from the view data



* email: The Email to update



###public virtual void Populate(Email email)





Updates an Email from the view data



* email: The Email to update



#PI.Pimail.Models.EmailFullView

File: EmailView.cs





A View class showing the entire email, inherits from EmailView



##Properties



###public string BodyHtml





Gets/sets the email body html value





Attributes

* [Required]





###public string BodyPlain





Gets/sets the email body plain text value





Attributes

* [Required]





###public List FilesToAttach





Gets/sets a list of fiels to attach



##Constructors



###public EmailFullView()





Default constructor for the class setting:

* IsBodyHtml = true;

* ContentEncoding = "utf-8";

* HeaderEncoding = "utf-8";

* Priority = MailPriority.Normal





###public EmailFullView(Email email)





Constructor for the class that populates the view from the email sent



* email: The email to populate the view with

##Methods



###public override Email Create(string userName = "Anonymous")





Creates an email from the view data



* userName: The user name of the creator

Returns: An Email model



###public override void Update(Email email)





Updates an Email from the view data



* email: The Email to update



###public override void Populate(Email email)





Updates an Email from the view data



* email: The Email to update

