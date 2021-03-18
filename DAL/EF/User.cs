namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            Orders = new HashSet<Order>();
        }

        [StringLength(50)]
        
        public string userID { get; set; }

        [StringLength(50, ErrorMessage = "Max length is 50 character!")]
        [DisplayName("Name")]
        [Required]
        public string fullName { get; set; }

        [StringLength(50)]
        [DisplayName("Password")]
        [Required]
        public string password { get; set; }

        [DisplayName("Status")]

        public bool? status { get; set; }

        [DisplayName("Day Create")]

        public DateTime? dateCreated { get; set; }

        [StringLength(10)]
        [DisplayName("Role")]
        public string roleID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Role Role { get; set; }
    }
}
