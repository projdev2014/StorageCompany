namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Package")]
    public partial class Package
    {
        public Package()
        {
            Product = new HashSet<Product>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string name { get; set; }

        [Required]
        public int width { get; set; }

        [Required]
        public int length { get; set; }

        [Required]
        public int height { get; set; }
        
        [Required]
        public int weight { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
