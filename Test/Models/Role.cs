namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Role")]
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "table_role_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string name { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
