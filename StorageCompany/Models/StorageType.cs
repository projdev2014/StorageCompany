namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StorageType")]
    public class StorageType
    {
        public StorageType()
        {
            Storage = new HashSet<Storage>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "table_storageType_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string name { get; set; }

        [Display(Name = "table_storageType_description", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string description { get; set; }

        [Display(Name = "table_storageType_maxWidth", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int maxWidth { get; set; }

        [Display(Name = "table_storageType_maxLength", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int maxLength { get; set; }

        [Display(Name = "table_storageType_maxHeight", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int maxHeight { get; set; }

        [Display(Name = "table_storageType_maxWeight", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int maxWeight { get; set; }

        public virtual ICollection<Storage> Storage { get; set; }
    }
}
