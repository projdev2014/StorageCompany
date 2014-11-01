namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movement")]
    public class Movement
    {
        public int id { get; set; }

        public int statusId { get; set; }

        public int orderId { get; set; }

        public int itemId { get; set; }

        public int storageId { get; set; }

        [Display(Name = "table_movement_dateDone", ResourceType = typeof(Ressources.StringsDispalyed))]
        public DateTime dateDone { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Order { get; set; }

        public virtual Status Status { get; set; }

        public virtual Storage Storage { get; set; }
    }
}
