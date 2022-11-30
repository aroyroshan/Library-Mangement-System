namespace LibraryMgmts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudentDb : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.SdtBookMappings", "BookId");
            CreateIndex("dbo.SdtBookMappings", "StudentId");
            AddForeignKey("dbo.SdtBookMappings", "BookId", "dbo.BookMgmt", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SdtBookMappings", "StudentId", "dbo.StudentEntities", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SdtBookMappings", "StudentId", "dbo.StudentEntities");
            DropForeignKey("dbo.SdtBookMappings", "BookId", "dbo.BookMgmt");
            DropIndex("dbo.SdtBookMappings", new[] { "StudentId" });
            DropIndex("dbo.SdtBookMappings", new[] { "BookId" });
        }
    }
}
