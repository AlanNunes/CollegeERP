namespace College2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users_subscriptions
    {
        public int id { get; set; }

        public int? subscription { get; set; }

        [Column(TypeName = "date")]
        public DateTime subscriptionDate { get; set; }

        [Required]
        [StringLength(255)]
        public string name_student { get; set; }

        [Column(TypeName = "date")]
        public DateTime birthday { get; set; }

        public virtual open_for_subscriptions open_for_subscriptions { get; set; }
    }
}
