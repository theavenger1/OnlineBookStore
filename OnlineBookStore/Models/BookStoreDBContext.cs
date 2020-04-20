namespace BookStore.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BookStoreDBContext : DbContext
    {
        public BookStoreDBContext()
            : base("name=BookStoreDBContext")
        {
        }

        public virtual DbSet<book> books { get; set; }
        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<city> cities { get; set; }
        public virtual DbSet<gov> govs { get; set; }
        public virtual DbSet<hub_travel_cost> hub_travel_cost { get; set; }
        public virtual DbSet<hub> hubs { get; set; }
        public virtual DbSet<hubs_admins> hubs_admins { get; set; }
        public virtual DbSet<order_item> order_items { get; set; }
        public virtual DbSet<order> orders { get; set; }
        public virtual DbSet<rate> rates { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<book>()
                .HasMany(e => e.order_items)
                .WithRequired(e => e.book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<category>()
                .HasMany(e => e.books)
                .WithRequired(e => e.category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<city>()
                .HasMany(e => e.users)
                .WithRequired(e => e.city)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<gov>()
                .HasMany(e => e.cities)
                .WithRequired(e => e.gov)
                .WillCascadeOnDelete(false);
           

            modelBuilder.Entity<hub_travel_cost>()
                .HasMany(e => e.order_items)
                .WithRequired(e => e.hub_travel_cost)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hub>()
                .HasMany(e => e.govs)
                .WithRequired(e => e.hub)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hub>()
                .HasMany(e => e.hubs_admins)
                .WithRequired(e => e.hub)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<hubs_admins>()
                .HasMany(e => e.order_items)
                .WithRequired(e => e.hubs_admins)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<order>()
                .HasMany(e => e.order_items)
                .WithRequired(e => e.order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<rate>()
                .HasMany(e => e.order_items)
                .WithRequired(e => e.rate)
                .HasForeignKey(e => e.rate_id1)
                .WillCascadeOnDelete(false);
          
            modelBuilder.Entity<user>()
                .HasMany(e => e.books)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.users_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.orders)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
