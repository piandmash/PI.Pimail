

#PI.Pimail.Models.IMailStore

File: IMailStore.cs





Interface for a mail store



##Methods



###IQueryable List()





A Queryable list of emails





###Email FindByName(string name)





Finds the object by name from the list



* name: The name to search on

Returns: A matching email or null



###Email Find(string id)





Finds the object by id from the list



* id: The id to search on

Returns: A matching email or null



###Email Create(Email email)





Creates the email within the data store



* email: The email to create

Returns: The created email



###Task[Email] CreateAsync(Email email)





Asynchronously creates the email within the data store



* email: The email to create

Returns: The created email



###Email Update(Email email)





Updates the email within the data store



* email: The email to update

Returns: The updated email



###Task[Email] UpdateAsync(Email email)





Asynchronously updates the email within the data store



* email: The email to update

Returns: The updated email



#PI.Pimail.Models.MailStoreDatabase

File: MailStoreDatabase.cs





Databased backed mail store using the IMailStore interface



##Properties



###private IPimailContext db = new PimailContext()





Sets the default IPimailContext to be used



##Constuctors



###public MailStoreDatabase()





Default empty constructor as used in live requests





###public MailStoreDatabase()





Constructors allow for context to be set for testing



* context: The IPimailContext to use for the store

##Methods IMailStore



###public IQueryable List()





A Queryable list of emails





###public Email FindByName(string name)





Finds the object by name from the list



* name: The name to search on

Returns: A matching email or null



###public Email Find(string id)





Finds the object by id from the list



* id: The id to search on

Returns: A matching email or null



###public Email Create(Email email)





Creates the email within the data store



* email: The email to create

Returns: The created email



###public Task[Email] CreateAsync(Email email)





Asynchronously creates the email within the data store



* email: The email to create

Returns: The created email



###public Email Update(Email email)





Updates the email within the data store



* email: The email to update

Returns: The updated email



###Task[Email] UpdateAsync(Email email)





Asynchronously updates the email within the data store



* email: The email to update

Returns: The updated email

##Methods 



###Task[Email] UpdateAsync(Email email)





Applies the copy email properties onto the original email



* original: The original email to populate

* copy: The email to copy



#PI.Pimail.Models.MailStoreXml

File: MailStoreXml.cs





Xml backed mail store using the IMailStore interface



##Properties



### private string Folder = ""





Sets the default folder for the Xml to be saved to



##Constuctors



###public MailStoreDatabase()





Default empty constructor as used in live requests





###public MailStoreDatabase()





Constructor with the folder set on creation



* folder: The folder value to set

##Methods IMailStore



###public IQueryable List()





A Queryable list of emails





###public Email FindByName(string name)





Finds the object by name from the list



* name: The name to search on

Returns: Always returns null as the string name is embeded within the Xml files and not in the FileInfo



###public Email Find(string id)





Finds the object by id from the list



* id: The id to search on

Returns: A matching email or null



###public Email Create(Email email)





Creates the email within the data store



* email: The email to create

Returns: The created email



###public Task[Email] CreateAsync(Email email)





Asynchronously creates the email within the data store



* email: The email to create

Returns: The created email



###public Email Update(Email email)





Updates the email within the data store



* email: The email to update

Returns: The updated email



###Task[Email] UpdateAsync(Email email)





Asynchronously updates the email within the data store



* email: The email to update

Returns: The updated email

##Methods



###Task[Email] UpdateAsync(Email email)





Applies the copy email properties onto the original email



* original: The original email to populate

* copy: The email to copy



###public IQueryable FileInfoList()





A Queryable list of emails based on FileInfo



