namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public class Status
    {
        public Status()
        {
            Movement = new HashSet<Movement>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "table_status_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string name { get; set; }

        [Display(Name = "table_status_description", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string description { get; set; }

        [Display(Name = "table_status_endingStatus", ResourceType = typeof(Ressources.StringsDispalyed))]
        public bool endingStatus { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
    }
}
