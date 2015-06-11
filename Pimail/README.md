

#PI.Pimail.IMail

File: IMail.cs





Interface for a mail object



##Properties



###string TagStart





The start tag used as a placeholder





###string TagEnd





The end tag used as a placeholder





###string FileRoot





The root folder for any file attachments



##Methods



###void Add(object key, object value)





Adds a key and it's value to the Hash Table



* key: The Hash Table key

* value: The object to to be stored



###void Remove(object key)





Removes a key pair from the hash table



* key: Key to remove



###void Clear()





Clears the hash table





###void AddObject(object itemToAdd, string prefix = "")





Adds in bulk object properties to an email.

The prefix should be added to the email parameters

in the xml email body

e.g. [PRIZE_DISPLAYNAME] where prefix is "PRIZE_"



* itemToAdd: The item to add to mail

* prefix: The parameters are prefixed with this to avoid duplicate addding of values such as id



### MailMessage BuildMailMessage(Email email)





Builds a mail message from the email object sent with the hash table values replaced



* email: The email to create the mail message from

Returns: New MailMessage



#PI.Pimail.Mail

File: Mail.cs





Default Mail Class using the IMail interface



##Properties



###public string TagStart





The start tag used as a placeholder





###public string TagEnd





The end tag used as a placeholder





###public string FileRoot





The root folder for any file attachments





###private Email m_LastSentEmail





Internally stores a reference to the last email sent via the object





###public Email LastSentEmail





Returns the last email sent via the object, get only



##Constructors



###public Mail(string fileRoot)





Default empty constructor with as used in live requests





###public Mail(string fileRoot)





Constructor with a file root set on creation, to allow for context for testing



* fileRoot: The fileRoot as a string

##Methods: Hash Table



###public void Add(object key, object value)





Adds a key and it's value to the Hash Table



* key: 

* Value: 



###public void Remove(object key)





Removes a key pair from the hash table



* key: Key to remove



###public void Clear()





Clears the hash table





###public void AddObject(object itemToAdd, string prefix = "")





Adds in bulk object properties to an email.

The prefix should be added to the email parameters

in the xml email body

e.g. [PRIZE_DISPLAYNAME] where prefix is "PRIZE_"



* itemToAdd: 

* prefix: The parameters are prefixed with this to avoid duplicate addding of values such as id



###private bool IsIEnumerable(Type someType)





Checks if a type is IEnumerable



* someType: The type to check for IEnumerable

Returns: true if the object is IEnumerable else returns false even on Exception

##Methods: Build



###public MailMessage BuildMailMessage(Email email)





Builds a mail message from the email object sent with the hash table values replaced



* email: The email to create the mail message from

Returns: New MailMessage



###private void SetAddresses(MailAddressCollection mac, string addresses)





Sets email address collection from semi-colon seperated address string



* mac: Email Address Collection

* addresses: Semi-colon seperated Email Addresses

##Methods: Merging



###private string ReplaceDynamicText(string t, Hashtable h = null)





Replaces text based on a hash table



* t: String

* h: Hash Table

Returns: String



###private string ReplaceDynamicText(string t, object o)





Replaces text based on the object sent



* t: Text

* o: Object

Returns: String

