namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(25)]
        public string username { get; set; }

        [Required]
        [StringLength(64)]
        public string password { get; set; }

        public int? roleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
