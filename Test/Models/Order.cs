namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public class Order
    {
        public Order()
        {
            Movement = new HashSet<Movement>();
        }

        public int id { get; set; }

        public int accountSenderId { get; set; }

        public int accountRecipientId { get; set; }

        public DateTime dateAsked { get; set; }

        public DateTime? dateEstimated { get; set; }

        public DateTime? dateDone { get; set; }

        public bool intern { get; set; }

        public virtual Account Account { get; set; }

        public virtual Account Account1 { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
    }
}
