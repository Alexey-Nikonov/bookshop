namespace REST
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int? PublisherId { get; set; }

        public decimal? Price { get; set; }

        public virtual Publisher Publisher { get; set; }
    }
}
