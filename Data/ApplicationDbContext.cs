using System;
using System.Collections.Generic;
using System.Text;
using InfotechVision.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfotechVision.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<ContentDetail> ContentDetails { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<EmailCampaignLandingPageTrack> EmailCampaignLandingPageTracks { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<News>()
                .HasOne<ContentDetail>(c => c.ContentDetail)
                .WithMany(n => n.News)
                .HasForeignKey(c => c.ContentID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
