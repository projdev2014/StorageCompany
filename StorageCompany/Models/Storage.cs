namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Storage")]
    public class Storage
    {
        public Storage()
        {
            Movement = new HashSet<Movement>();
            Storage1 = new HashSet<Storage>();
        }

        public int id { get; set; }

        public int storageTypeId { get; set; }

        [Display(Name = "table_storageType_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int? storageParentId { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "table_storage_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string name { get; set; }

        [ScaffoldColumn(false)]
        [Display(Name = "table_storage_usable", ResourceType = typeof(Ressources.StringsDispalyed))]
        public bool usable { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }

        public virtual StorageType StorageType { get; set; }

        public virtual ICollection<Storage> Storage1 { get; set; }

        public virtual Storage Storage2 { get; set; }
    }
}
