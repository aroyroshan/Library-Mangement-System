using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LibraryMgmts
{
    [Table("BookMgmt")]
    public class BookEntity
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string Author { get; set; }
        public bool InStock { get; set; }

    }
}