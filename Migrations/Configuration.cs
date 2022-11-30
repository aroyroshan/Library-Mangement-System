namespace LibraryMgmts.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LibraryMgmts.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LibraryMgmts.LibraryContext context)
        {
            if (!context.User.Any())
            {
                UserEntity adminuser = new UserEntity
                {
                    Name = "Admin",
                    UserName = "AdminLab",
                    Password = "12345"
                };

                context.User.Add(adminuser);
                context.SaveChanges();
            }
        }
    }
}
