using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CallFlow
{
    public partial class CallFlowContext : DbContext
    {
        public CallFlowContext()
        {
        }

        public CallFlowContext(DbContextOptions<CallFlowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessAllow> AccessAllows { get; set; }
        public virtual DbSet<ChatMessage> ChatMessages { get; set; }
        public virtual DbSet<Contact_Now> Contact_Now { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-A6NL43V\\SQLEXPRESS;Database=CallFlow;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessAllow>(entity =>
            {

                entity.ToTable("Access_Allow");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName).HasColumnName("FirstName").HasMaxLength(50);

                entity.Property(e => e.LastName).HasColumnName("LastName").HasMaxLength(50);

                entity.Property(e => e.UserName).HasColumnName("UserName").HasMaxLength(50);

                entity.Property(e => e.Password).HasColumnName("Password").HasMaxLength(50);

                entity.Property(e => e.Status).HasColumnName("Status").HasMaxLength(50);

            });

            modelBuilder.Entity<ChatMessage>(entity =>
            {

                entity.ToTable("Chat_Message");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Username).HasColumnName("Username").HasMaxLength(50);

                entity.Property(e => e.Message).HasColumnName("Message").HasMaxLength(int.MaxValue);

            });

            modelBuilder.Entity<Contact_Now>(entity =>
            {

                entity.ToTable("Contact_Now");

                entity.Property(e => e.id).HasColumnName("id");

                entity.Property(e => e.UserName).HasColumnName("UserName").HasMaxLength(50);

                entity.Property(e => e.IsType).HasColumnName("IsType").HasMaxLength(50);

                entity.Property(e => e.date).HasColumnName("date");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
