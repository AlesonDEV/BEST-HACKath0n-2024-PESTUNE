using BloodFlow.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodFlow.DataLayer.Data
{
    public class BloodFlowDbContext : DbContext
    {
        public BloodFlowDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

        // DbSets
        public DbSet<Person> Persons { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<BloodType> BloodTypes { get; set; }

        public DbSet<Contact> ContactTypes { get; set; }

        public DbSet<Donor> Donors { get; set; }

        public DbSet<DonorCenter> DonorsCenter { get; set;}

        public DbSet<DonorOrder> DonorOrders { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<Street> Streets { get; set; }

        public DbSet<Importance> Importances { get; set; }

        // FluentApi
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // donor_order - ManyToMany
            modelBuilder.Entity<DonorOrder>()
                .HasKey(dor => new { dor.DonorId, dor.OrderId });

            modelBuilder.Entity<DonorOrder>()
                .HasOne(dor => dor.Donor)
                .WithMany(d => d.DonorOrders)
                .HasForeignKey(dor => dor.DonorId);

            modelBuilder.Entity<DonorOrder>()
                .HasOne(dor => dor.Order)
                .WithMany(o => o.DonorOrders)
                .HasForeignKey(dor => dor.OrderId);

            // person - OneToOne
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Donor)
                .WithOne(d => d.Person)
                .HasForeignKey<Donor>(d => d.Id);

            modelBuilder.Entity<Donor>()
               .HasOne(d => d.Person)
               .WithOne(p => p.Donor)
               .HasForeignKey<Person>(p => p.Id);

            modelBuilder.UseIdentityColumns();
        }
    }
}