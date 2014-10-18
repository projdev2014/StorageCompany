namespace StorageCompany.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Account")]
    public class Account
    {
        public Account()
        {
            Order = new HashSet<Order>();
            Order1 = new HashSet<Order>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "table_account_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string name { get; set; }

        [Display(Name = "table_account_entrepriseNumber", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int? entrepriseNumber { get; set; }

        [Display(Name = "table_account_city", ResourceType = typeof(Ressources.StringsDispalyed))]
        [StringLength(50)]
        public string city { get; set; }

        [StringLength(10)]
        [Display(Name = "table_account_postalCode", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string postalCode { get; set; }

        [StringLength(10)]
        [Display(Name = "table_account_streetNumber", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string streetNumber { get; set; }

        [StringLength(50)]
        [Display(Name = "table_account_streetName", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string streetName { get; set; }

        [StringLength(50)]
        [Display(Name = "table_account_country", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string country { get; set; }

        [StringLength(50)]
        [Display(Name = "table_account_email", ResourceType = typeof(Ressources.StringsDispalyed))]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [Display(Name = "table_account_intern", ResourceType = typeof(Ressources.StringsDispalyed))]
        public bool intern { get; set; }

        public virtual ICollection<Order> Order { get; set; }

        public virtual ICollection<Order> Order1 { get; set; }
    }
}
