using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StorageCompany.Models.StoredProcedure
{
    public class ListMovement
    {

        public int id { get; set; }

        [Display(Name = "table_order_type", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string type { get; set; }
        
        [Display(Name = "table_movement_status", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string status { get; set; }

        [Display(Name = "table_movement_product", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string product { get; set; }

        [Display(Name = "table_movement_newStorage", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string newStorage { get; set; }

        [Display(Name = "table_movement_oldStorage", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string oldStorage { get; set; }

        [Display(Name = "table_movement_dateDone", ResourceType = typeof(Ressources.StringsDispalyed))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public Nullable<System.DateTime> dateDone { get; set; }

        [Display(Name = "table_movement_timeExpire", ResourceType = typeof(Ressources.StringsDispalyed))]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public Nullable<System.DateTime> timeExpire { get; set; }

    }
}