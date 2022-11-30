using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace LibraryMgmts
{
   //[Table("BookStudent")]
    public class SdtBookMapping
    {
        public int Id { get; set; }
        [ForeignKey("Book")]
        public int BookId { get; set; }
        public BookEntity Book { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public StudentEntity Student { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}