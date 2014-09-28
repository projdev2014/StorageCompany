namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Status
    {
        public Status()
        {
            Movement = new HashSet<Movement>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        public string name { get; set; }

        public string description { get; set; }

        public bool endingStatus { get; set; }

        public virtual ICollection<Movement> Movement { get; set; }
    }
}
