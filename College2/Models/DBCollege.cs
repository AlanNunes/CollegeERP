namespace College2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DBCollege : DbContext
    {
        public DBCollege()
            : base("name=DBCollege")
        {
        }

        public virtual DbSet<cours> courses { get; set; }
        public virtual DbSet<courses_type> courses_type { get; set; }
        public virtual DbSet<open_for_subscriptions> open_for_subscriptions { get; set; }
        public virtual DbSet<role> roles { get; set; }
        public virtual DbSet<user> users { get; set; }
        public virtual DbSet<users_subscriptions> users_subscriptions { get; set; }
        public virtual DbSet<Cities> Cities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<cours>()
                .HasMany(e => e.open_for_subscriptions)
                .WithOptional(e => e.cours)
                .HasForeignKey(e => e.course);

            modelBuilder.Entity<courses_type>()
                .HasMany(e => e.courses)
                .WithOptional(e => e.courses_type)
                .HasForeignKey(e => e.course_type);

            modelBuilder.Entity<open_for_subscriptions>()
                .HasMany(e => e.users_subscriptions)
                .WithOptional(e => e.open_for_subscriptions)
                .HasForeignKey(e => e.subscription);

            modelBuilder.Entity<role>()
                .HasMany(e => e.users)
                .WithOptional(e => e.role1)
                .HasForeignKey(e => e.role);

            modelBuilder.Entity<Cities>()
                .HasMany(e => e.Open_For_Subscriptions)
                .WithOptional(e => e.Cities)
                .HasForeignKey(e => e.City);
        }
    }
}
