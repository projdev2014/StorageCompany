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

        [Display(Name = "table_package_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int packageId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "table_product_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string name { get; set; }

        [Display(Name = "table_product_description", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string description { get; set; }

        [Display(Name = "table_product_stockMin", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int? stockMin { get; set; }

        [Display(Name = "table_product_stockMax", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int? stockMax { get; set; }

        public virtual ICollection<Item> Item { get; set; }

        public virtual Package Package { get; set; }
    }
}
