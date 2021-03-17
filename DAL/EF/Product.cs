namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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

        [StringLength(50, ErrorMessage = "Max length is 50 character!")]
        [DisplayName("Product Name")]
        [Required(ErrorMessage = "You must enter Product's Name!")]
        public string productName { get; set; }

        
        [DisplayName("Upload Picture")]
        public string imageLink { get; set; }

        [NotMapped]
        public HttpPostedFileBase imageFile { get; set; }

        [DisplayName("Price")]
        [Required(ErrorMessage = "You must enter Product's Price!")]

        public double? price { get; set; }

        [DisplayName("Quantity")]
        [Required(ErrorMessage = "You must enter Product's Quantity!")]
        public int? quantity { get; set; }

        public DateTime? dayCreated { get; set; }

        [StringLength(100, ErrorMessage = "Max length is 100 character!")]
        [DisplayName("Description")]

        public string description { get; set; }

        [DisplayName("Status")]
        public bool? status { get; set; }

        [StringLength(10)]
        [DisplayName("Brand")]
        [Required(ErrorMessage = "You must enter Product's Brand!")]

        public string brandID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }

        public virtual Brand Brand { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
