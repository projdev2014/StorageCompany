using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StorageCompany.Models.StoredProcedure
{
    public class ItemIn
    {
        public int id { get; set; }

        [Display(Name = "table_item_timeExpire", ResourceType = typeof(Ressources.StringsDispalyed))]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? timeExpire { get; set; }

        [Display(Name = "table_product_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int productId { get; set; }

        [Display(Name = "table_storage_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int storageId { get; set; }

        public virtual Storage Storage { get; set; }

        public virtual Product Product { get; set; }

    }
}