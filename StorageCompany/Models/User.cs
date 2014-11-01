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
        [Display(Name = "table_user_firstname", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string firstname { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "table_user_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string name { get; set; }

        [Required]
        [StringLength(25)]
        [Display(Name = "table_user_username", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string username { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "table_user_password", ResourceType = typeof(Ressources.StringsDispalyed))]
        public string password { get; set; }

        [Display(Name = "table_role_name", ResourceType = typeof(Ressources.StringsDispalyed))]
        public int? roleId { get; set; }

        public virtual Role Role { get; set; }
    }

    public class ManageUserViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe actuel")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(64, ErrorMessage = "La chaîne {0} doit comporter au moins {2} caractères.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nouveau mot de passe")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le nouveau mot de passe")]
        [Compare("NewPassword", ErrorMessage = "Le nouveau mot de passe et le mot de passe de confirmation ne correspondent pas.")]
        public string ConfirmPassword { get; set; }
    }
}
