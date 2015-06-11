namespace PI.Pimail.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pimail1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Emails", "Id", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Emails");
            AddPrimaryKey("dbo.Emails", "Id");
            AlterStoredProcedure(
                "dbo.Email_Insert",
                p => new
                    {
                        Id = p.String(maxLength: 128),
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
                    @"INSERT [dbo].[Emails]([Id], [Name], [To], [Subject], [BodyHtml], [BodyPlain], [From], [FromDisplay], [Cc], [IsBodyHtml], [AdditionalHeaders], [Bcc], [ContentEncoding], [HeaderEncoding], [Priority], [ReplyTo], [Deleted], [Archived], [Creator], [Created], [Updator], [Updated])
                      VALUES (@Id, @Name, @To, @Subject, @BodyHtml, @BodyPlain, @From, @FromDisplay, @Cc, @IsBodyHtml, @AdditionalHeaders, @Bcc, @ContentEncoding, @HeaderEncoding, @Priority, @ReplyTo, @Deleted, @Archived, @Creator, @Created, @Updator, @Updated)"
            );
            
            AlterStoredProcedure(
                "dbo.Email_Update",
                p => new
                    {
                        Id = p.String(maxLength: 128),
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
                      SET [Name] = @Name, [To] = @To, [Subject] = @Subject, [BodyHtml] = @BodyHtml, [BodyPlain] = @BodyPlain, [From] = @From, [FromDisplay] = @FromDisplay, [Cc] = @Cc, [IsBodyHtml] = @IsBodyHtml, [AdditionalHeaders] = @AdditionalHeaders, [Bcc] = @Bcc, [ContentEncoding] = @ContentEncoding, [HeaderEncoding] = @HeaderEncoding, [Priority] = @Priority, [ReplyTo] = @ReplyTo, [Deleted] = @Deleted, [Archived] = @Archived, [Creator] = @Creator, [Created] = @Created, [Updator] = @Updator, [Updated] = @Updated
                      WHERE ([Id] = @Id)"
            );
            
            AlterStoredProcedure(
                "dbo.Email_Delete",
                p => new
                    {
                        Id = p.String(maxLength: 128),
                    },
                body:
                    @"DELETE [dbo].[Emails]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Emails");
            AddPrimaryKey("dbo.Emails", "Name");
            DropColumn("dbo.Emails", "Id");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
