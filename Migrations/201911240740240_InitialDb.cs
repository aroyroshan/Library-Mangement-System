namespace LibraryMgmts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookLibrary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        Author = c.String(),
                        InStock = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SdtBookMappings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        IssueDate = c.DateTime(nullable: false),
                        ReturnDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StudentEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Class = c.String(),
                        Address = c.String(),
                        gmail = c.String(),
                        PhoneNumber = c.String(),
                        Department = c.String(),
                        Session = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.StudentEntities");
            DropTable("dbo.SdtBookMappings");
            DropTable("dbo.BookLibrary");
        }
    }
}
