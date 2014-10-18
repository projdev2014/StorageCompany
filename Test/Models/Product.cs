namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public class Product
    {
        public Product()
        {
            Item = new HashSet<Item>();
        }

        public int id { get; set; }

        public int packageId { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public string description { get; set; }

        public int? stockMin { get; set; }

        public int? stockMax { get; set; }

        public virtual ICollection<Item> Item { get; set; }

        public virtual Package Package { get; set; }
    }
}
