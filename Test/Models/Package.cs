namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Package")]
    public class Package
    {
        public Package()
        {
            Product = new HashSet<Product>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "table_package_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string name { get; set; }

        [Display(Name = "table_package_width", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int width { get; set; }

        [Display(Name = "table_package_length", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int length { get; set; }

        [Display(Name = "table_package_height", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int height { get; set; }

        [Display(Name = "table_package_weight", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int weight { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
