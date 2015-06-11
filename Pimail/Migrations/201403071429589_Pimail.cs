namespace PI.Pimail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pimail : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        To = c.String(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 128),
                        BodyHtml = c.String(nullable: false),
                        BodyPlain = c.String(nullable: false),
                        From = c.String(nullable: false),
                        FromDisplay = c.String(),
                        Cc = c.String(),
                        IsBodyHtml = c.Boolean(nullable: false),
                        AdditionalHeaders = c.String(),
                        Bcc = c.String(),
                        ContentEncoding = c.String(nullable: false),
                        HeaderEncoding = c.String(nullable: false),
                        Priority = c.Int(nullable: false),
                        ReplyTo = c.String(),
                        Deleted = c.Boolean(nullable: false),
                        Archived = c.Boolean(nullable: false),
                        Creator = c.String(nullable: false, maxLength: 256),
                        Created = c.DateTime(nullable: false),
                        Updator = c.String(nullable: false, maxLength: 256),
                        Updated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateStoredProcedure(
                "dbo.Email_Insert",
                p => new
                    {
                        Name = p.String(maxLength: 128),
                        To = p.String(),
                        Subject = p.String(maxLength: 128),
                        BodyHtml = p.String(),
                        BodyPlain = p.String(),
                        From = p.String(),
                        FromDisplay = p.String(),
                        Cc = p.String(),
                        IsBodyHtml = p.Boolean(),
                        AdditionalHeaders = p.String(),
                        Bcc = p.String(),
                        ContentEncoding = p.String(),
                        HeaderEncoding = p.String(),
                        Priority = p.Int(),
                        ReplyTo = p.String(),
                        Deleted = p.Boolean(),
                        Archived = p.Boolean(),
                        Creator = p.String(maxLength: 256),
                        Created = p.DateTime(),
                        Updator = p.String(maxLength: 256),
                        Updated = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[Emails]([Name], [To], [Subject], [BodyHtml], [BodyPlain], [From], [FromDisplay], [Cc], [IsBodyHtml], [AdditionalHeaders], [Bcc], [ContentEncoding], [HeaderEncoding], [Priority], [ReplyTo], [Deleted], [Archived], [Creator], [Created], [Updator], [Updated])
                      VALUES (@Name, @To, @Subject, @BodyHtml, @BodyPlain, @From, @FromDisplay, @Cc, @IsBodyHtml, @AdditionalHeaders, @Bcc, @ContentEncoding, @HeaderEncoding, @Priority, @ReplyTo, @Deleted, @Archived, @Creator, @Created, @Updator, @Updated)"
            );
            
            CreateStoredProcedure(
                "dbo.Email_Update",
                p => new
                    {
                        Name = p.String(maxLength: 128),
                        To = p.String(),
                        Subject = p.String(maxLength: 128),
                        BodyHtml = p.String(),
                        BodyPlain = p.String(),
                        From = p.String(),
                        FromDisplay = p.String(),
                        Cc = p.String(),
                        IsBodyHtml = p.Boolean(),
                        AdditionalHeaders = p.String(),
                        Bcc = p.String(),
                        ContentEncoding = p.String(),
                        HeaderEncoding = p.String(),
                        Priority = p.Int(),
                        ReplyTo = p.String(),
                        Deleted = p.Boolean(),
                        Archived = p.Boolean(),
                        Creator = p.String(maxLength: 256),
                        Created = p.DateTime(),
                        Updator = p.String(maxLength: 256),
                        Updated = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[Emails]
                      SET [To] = @To, [Subject] = @Subject, [BodyHtml] = @BodyHtml, [BodyPlain] = @BodyPlain, [From] = @From, [FromDisplay] = @FromDisplay, [Cc] = @Cc, [IsBodyHtml] = @IsBodyHtml, [AdditionalHeaders] = @AdditionalHeaders, [Bcc] = @Bcc, [ContentEncoding] = @ContentEncoding, [HeaderEncoding] = @HeaderEncoding, [Priority] = @Priority, [ReplyTo] = @ReplyTo, [Deleted] = @Deleted, [Archived] = @Archived, [Creator] = @Creator, [Created] = @Created, [Updator] = @Updator, [Updated] = @Updated
                      WHERE ([Name] = @Name)"
            );
            
            CreateStoredProcedure(
                "dbo.Email_Delete",
                p => new
                    {
                        Name = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Emails]
                      WHERE ([Name] = @Name)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Email_Delete");
            DropStoredProcedure("dbo.Email_Update");
            DropStoredProcedure("dbo.Email_Insert");
            DropTable("dbo.Emails");
        }
    }
}
