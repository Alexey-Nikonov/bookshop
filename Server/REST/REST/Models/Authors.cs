using System.Runtime.Serialization;

namespace REST.Models
{
    [KnownType(typeof(Authors))]
    public class Authors
    {
        public int Id { get; set; }
        public string Alias { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}