namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Item")]
    public partial class Item
    {
        public Item()
        {
            Movement = new HashSet<Movement>();
        }

        public int id { get; set; }

        public int productId { get; set; }

        public DateTime? timeExpire { get; set; }

        public virtual Product Product { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
    }
}
