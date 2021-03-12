namespace DAL.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ActivityLog
    {
        public int activityLogID { get; set; }

        [StringLength(50)]
        public string userID { get; set; }

        public int? productID { get; set; }

        public DateTime? date { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
