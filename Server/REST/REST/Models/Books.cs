using System.Runtime.Serialization;

namespace REST.Models
{
    [KnownType(typeof(Books))]
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? PublisherId { get; set; }
        public decimal? Price { get; set; }
    }
}