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

        public int order_id { get; set; }

        public int? from_hub_id { get; set; }

        public int? to_hub_id { get; set; }

        [StringLength(45)]
        public string cost { get; set; }

        public int hub_travel_cost_id { get; set; }

        public int admin_id { get; set; }

        public int rate_id1 { get; set; }

        public int book_id { get; set; }

        public virtual book book { get; set; }

        public virtual hub_travel_cost hub_travel_cost { get; set; }

        public virtual hubs_admins hubs_admins { get; set; }

        public virtual order order { get; set; }

        public virtual rate rate { get; set; }
    }
}
