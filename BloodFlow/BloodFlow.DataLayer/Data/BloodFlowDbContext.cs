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

        public DbSet<ContactType> ContactTypes { get; set; }

        public DbSet<Donor> Donors { get; set; }

        public DbSet<DonorCenter> DonorsCenter { get; set;}

        public DbSet<DonorCenterContact> DonorCenterContacts { get; set; }

        public DbSet<DonorOrder> DonorOrders { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Person> People { get; set; }

        public DbSet<PersonContact> PeopleContacts { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<StateSession> States { get; set; }

        public DbSet<Street> Streets { get; set; }

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

            // donor_session - ManyToMany
            modelBuilder.Entity<DonorSession>()
                 .HasKey(ds => new { ds.DonorId, ds.SessionId });

            modelBuilder.Entity<DonorSession>()
                .HasOne(ds => ds.Donor)
                .WithMany(d => d.DonorSessions)
                .HasForeignKey(ds => ds.DonorId);

            modelBuilder.Entity<DonorSession>()
                .HasOne(ds => ds.Session)
                .WithMany(s => s.DonorSessions)
                .HasForeignKey(ds => ds.SessionId);

            // session_donor_center - ManyToMany
            modelBuilder.Entity<SessionDonorCenter>()
                .HasKey(sdc => new { sdc.SessionId, sdc.DonorCenterId });

            modelBuilder.Entity<SessionDonorCenter>()
                .HasOne(sdc => sdc.Session)
                .WithMany(s => s.SessionDonorCenters)
                .HasForeignKey(sdc => sdc.SessionId);

            modelBuilder.Entity<SessionDonorCenter>()
                .HasOne(sdc => sdc.DonorCenter)
                .WithMany(dc => dc.SessionDonorCenters)
                .HasForeignKey(sdc => sdc.DonorCenterId);

            // person_contact - ManyToMany
            modelBuilder.Entity<PersonContact>()
                .HasKey(pc => new { pc.PersonId, pc.ContactTypeId });

            modelBuilder.Entity<PersonContact>()
                .HasOne(pc => pc.Person)
                .WithMany(p => p.PersonContacts)
                .HasForeignKey(pc => pc.PersonId);

            modelBuilder.Entity<PersonContact>()
                .HasOne(pc => pc.ContactType)
                .WithMany(ct => ct.PersonContacts)
                .HasForeignKey(pc => pc.ContactTypeId);

            // donor_center_contact - ManyToMany
            modelBuilder.Entity<DonorCenterContact>()
                .HasKey(dcc => new { dcc.DonorCenterId, dcc.ContactTypeId });

            modelBuilder.Entity<DonorCenterContact>()
                .HasOne(dcc => dcc.DonorCenter)
                .WithMany(dc => dc.DonorCenterContacts)
                .HasForeignKey(dcc => dcc.DonorCenterId);

            modelBuilder.Entity<DonorCenterContact>()
                .HasOne(dcc => dcc.ContactType)
                .WithMany(c => c.DonorCenterContacts)
                .HasForeignKey(dcc => dcc.ContactTypeId);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.DonorCenter)
                .WithMany(dc => dc.Orders)
                .HasForeignKey(o => o.DonorCenterId);

            modelBuilder.UseIdentityColumns();
        }
    }
}