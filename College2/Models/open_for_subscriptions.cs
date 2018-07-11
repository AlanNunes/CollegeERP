namespace College2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class open_for_subscriptions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public open_for_subscriptions()
        {
            users_subscriptions = new HashSet<users_subscriptions>();
        }

        [Key]
        public int id { get; set; }

        [Display(Name = "Course")]
        public int? course { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Status")]
        public byte status { get; set; }

        [Required(ErrorMessage = "The start date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Date Start")]
        [Column(TypeName = "date")]
        public DateTime dateStart { get; set; }

        [Required(ErrorMessage = "The end date is required")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        [Column(TypeName = "date")]
        public DateTime dateEnd { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Limit of Subscriptions")]
        public int limitSubscriptions { get; set; }

        [Display(Name = "City")]
        public int? City { get; set; }

        public virtual Cities Cities { get; set; }

        public virtual cours cours { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<users_subscriptions> users_subscriptions { get; set; }
    }
}
