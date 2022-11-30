namespace LibraryMgmts.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Student : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BookLibrary", newName: "BookMgmt");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.BookMgmt", newName: "BookLibrary");
        }
    }
}
