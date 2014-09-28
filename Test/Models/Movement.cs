namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Movement")]
    public partial class Movement
    {
        public int id { get; set; }

        [Required]
        public int statusId { get; set; }

        [Required]
        public int orderId { get; set; }

        [Required]
        public int itemId { get; set; }

        [Required]
        public int storageId { get; set; }

        [Required]
        public DateTime dateDone { get; set; }

        public virtual Item Item { get; set; }

        public virtual Order Order { get; set; }

        public virtual Status Status { get; set; }

        public virtual Storage Storage { get; set; }
    }
}
