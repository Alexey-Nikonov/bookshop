using System.Runtime.Serialization;

namespace REST.Models
{
    [KnownType(typeof(BooksAuthors))]
    public class BooksAuthors
    {
        public int Id { get; set; }
        public int? BookId { get; set; }
        public int? AuthorId { get; set; }
    }
}