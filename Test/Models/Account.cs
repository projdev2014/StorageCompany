namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public partial class Account
    {
        public Account()
        {
            Order = new HashSet<Order>();
            Order1 = new HashSet<Order>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string name { get; set; }

        public int? entrepriseNumber { get; set; }

        [StringLength(50)]
        public string city { get; set; }

        [StringLength(10)]
        public string postalCode { get; set; }

        [StringLength(10)]
        public string streetNumber { get; set; }

        [StringLength(50)]
        public string streetName { get; set; }

        [StringLength(50)]
        public string country { get; set; }

        [StringLength(50)]
        [RegularExpression(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?", ErrorMessage="Adresse mail non valide")]
        public string email { get; set; }

        public bool intern { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public virtual ICollection<Order> Order1 { get; set; }
    }
}
