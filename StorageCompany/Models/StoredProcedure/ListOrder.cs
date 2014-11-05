using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StorageCompany.Models.StoredProcedure
{
    public class ListOrder
    {
        public int id { get; set; }
            
        [Display(Name = "table_order_type", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string type { get; set; }

        [Display(Name = "table_order_accountSender", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string senderName { get; set; }
            
        [Display(Name = "table_order_accountRecipient", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string recipientName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        [Display(Name = "table_order_dateAsked", ResourceType = typeof(Ressources.StringsDispalyed))]
        public System.DateTime dateAsked { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy HH:mm}")]
        [Display(Name = "table_order_dateEstimated", ResourceType = typeof(Ressources.StringsDispalyed))]
        public Nullable<System.DateTime> dateEstimated { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy HH:mm}")]
        [Display(Name = "table_order_dateDone", ResourceType = typeof(Ressources.StringsDispalyed))]
        public Nullable<System.DateTime> dateDone { get; set; }
    }
}