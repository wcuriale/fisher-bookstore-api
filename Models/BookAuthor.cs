using System.Collections.Generic;

namespace Fisher.Bookstore.Models 
{
    public class BookAuthor//bridgeclass
    {
        public int BookId {get; set;}
        public Book Book {get; set;} //navigation property
        public int AuthorId {get; set;}
        public Author Author {get; set;} //navigation property
    }
}