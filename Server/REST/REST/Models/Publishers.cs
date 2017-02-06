using System.Runtime.Serialization;

namespace REST.Models
{
    [KnownType(typeof(Publishers))]
    public class Publishers
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}