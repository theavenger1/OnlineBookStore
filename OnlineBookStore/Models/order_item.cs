namespace BookStore.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("mydb.order items")]
    public partial class order_item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }
        public int no_of_items { get; set; }

        [ForeignKey("order")]
        public int order_id { get; set; }

        [StringLength(45)]
        public string cost { get; set; }

        [ForeignKey("hub_travel_cost")]
        public int hub_travel_cost_id { get; set; }

        [ForeignKey("hubs_admins")]
        public int admin_id { get; set; }

        [ForeignKey("book")]
        public int book_id { get; set; }

        public virtual book book { get; set; }

        public virtual hub_travel_cost hub_travel_cost { get; set; }

        public virtual hubs_admins hubs_admins { get; set; }

        public virtual order order { get; set; }

    }
}
