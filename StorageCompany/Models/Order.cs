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

        [Display(Name = "table_order_accountSender", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int accountSenderId { get; set; }

        [Display(Name = "table_order_accountRecipient", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int accountRecipientId { get; set; }

        [Display(Name = "table_order_dateAsked", ResourceType = typeof(Ressources.StringsDispalyed))]
        public DateTime dateAsked { get; set; }

        [Display(Name = "table_order_dateEstimated", ResourceType = typeof(Ressources.StringsDispalyed))]
        public DateTime? dateEstimated { get; set; }

        [Display(Name = "table_order_dateDone", ResourceType = typeof(Ressources.StringsDispalyed))]
        public DateTime? dateDone { get; set; }

        [Display(Name = "table_order_intern", ResourceType = typeof(Ressources.StringsDispalyed))]
        public bool intern { get; set; }

        public virtual Account Account { get; set; }

        public virtual Account Account1 { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
    }
}
