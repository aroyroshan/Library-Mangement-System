using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LibraryMgmts
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("LibraryContext")
        {

        }
        public DbSet<BookEntity> BookStudent { get; set; }
        public DbSet<StudentEntity> Student { get; set; }
        public DbSet<SdtBookMapping> BookStudentMapping { get; set; }
        public DbSet<UserEntity> User { get; set; }
    }


}