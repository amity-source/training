namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("User")]
    public partial class User
    {
        public long ID { get; set; }

        [StringLength(50)]
        [Display(Name = "username")]
        public string UserName { get; set; }

        [StringLength(32)]
        [Display(Name = "password")]
        public string Password { get; set; }

        [StringLength(50)]
        [Display(Name = "name")]
        public string Name { get; set; }

        [StringLength(50)]
        [Display(Name = "address")]
        public string Address { get; set; }

        [StringLength(50)]
        [Display(Name = "email")]
        public string Email { get; set; }

        [StringLength(50)]
        [Display(Name = "phone")]
        public string Phone { get; set; }

        [StringLength(50)]
        public string CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifedDate { get; set; }

        [StringLength(50)]
        public string ModifedBy { get; set; }

        //changed to normal bool (not nullable)
        public bool Status { get; set; }
    }
}
