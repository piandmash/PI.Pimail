

#PI.Pimail.Models.IPimailContext

File: IPimailContext.cs





Interface for the Context used in saving the mail object to a data store using Entity Framework



##Properties



###DbSet Emails





DBSet of emails, get only



##Methods



###int SaveChanges()





Saves all changes made in this context to the underlying store.



Returns: The number of objects written to the underlying store.



###Task[int] SaveChangesAsync()





Asynchronously saves all changes made in this context to the underlying store.



Returns: A task that represents the asynchronous save operation.  The task result contains the number of objects written to the underlying store.



###Task[int] SaveChangesAsync(CancellationToken cancellationToken)





Asynchronously saves all changes made in this context to the underlying store.



* cancellationToken: A System.Threading.CancellationToken to observe while waiting for the task to complete.

Returns: A task that represents the asynchronous save operation.  The task result contains the number of objects written to the underlying store.



###void MarkAsModified(object item)





Sets the EntityState of the object to Modified



* item: The item to update



#PI.Pimail.Models.PimailContext

File: PimailContext.cs





DbContext used in saving the mail object to a database Entity Framework, implementing the IPimailContext



##Properties



###public DbSet Emails





DBSet of emails



##Constructors



###public PimailContext()





Default constuctor sets the nameOrConnectionString to PimailContext

Constructs a new context instance using conventions to create the name of

the database to which a connection will be made. The by-convention name is

the full name (namespace + class name) of the derived context class.  See

the class remarks for how this is used to create a connection.





Constructs a new context instance using the given string as the name or connection 

string for the database to which a connection will be made.  See the class

remarks for how this is used to create a connection.



* nameOrConnectionString: Either the database name or a connection string

##Methods



###public void MarkAsModified(object item)





Sets the EntityState of the object to Modified



* item: The item to update



###protected override void OnModelCreating(DbModelBuilder modelBuilder)





Override of the OnModelCreating method used to map the entity to stored procedures



* modelBuilder: The builder that defines the model for the context being created.

