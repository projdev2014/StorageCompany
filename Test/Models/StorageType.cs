namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StorageType")]
    public partial class StorageType
    {
        public StorageType()
        {
            Storage = new HashSet<Storage>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string name { get; set; }

        public string description { get; set; }

        public int maxWidth { get; set; }

        public int maxLength { get; set; }

        public int maxHeight { get; set; }

        public int maxWeight { get; set; }

        public virtual ICollection<Storage> Storage { get; set; }
    }
}
