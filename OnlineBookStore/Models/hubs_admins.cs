namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.hubs_admins")]
    public partial class hubs_admins
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hubs_admins()
        {
            order_items = new HashSet<order_item>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        [StringLength(45)]
        public string admin_name { get; set; }

        [StringLength(45)]
        public string admin_email { get; set; }

        [StringLength(45)]
        public string admin_password { get; set; }

        public int hub_id { get; set; }

        [StringLength(45)]
        public string admin_permissions { get; set; }

        public virtual hub hub { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_item> order_items { get; set; }
    }
}
