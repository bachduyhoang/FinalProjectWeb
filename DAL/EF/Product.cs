namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int productID { get; set; }

        [StringLength(50)]
        public string productName { get; set; }

        [StringLength(300)]
        public string imageLink { get; set; }
        
        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }

        public double? price { get; set; }

        public int? quantity { get; set; }

        public DateTime? dayCreated { get; set; }

        [StringLength(100)]
        public string description { get; set; }

        public bool? status { get; set; }

        [Required]
        [StringLength(10)]
        public string brandID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
