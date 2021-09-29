using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AdvisoryLawyer.Data.Models
{
    public partial class AdvisoryLawyerContext : DbContext
    {
        public AdvisoryLawyerContext()
        {
        }

        public AdvisoryLawyerContext(DbContextOptions<AdvisoryLawyerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Advisory> Advisories { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<CaseItem> CaseItems { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CategoryLawyer> CategoryLawyers { get; set; }
        public virtual DbSet<CategoryLawyerOffice> CategoryLawyerOffices { get; set; }
        public virtual DbSet<CustomerCase> CustomerCases { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<DocumentCase> DocumentCases { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<UserAccount> UserAccounts { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=104.215.186.78,1433;Database=AdvisoryLawyer;User Id=sa;Password=Khoa123456789;Trusted_Connection=False;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Advisory>(entity =>
            {
                entity.ToTable("Advisory");

                entity.Property(e => e.QuestionAnswer)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.StartAdvisory).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.AdvisoryCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Advisory__Custom__164452B1");

                entity.HasOne(d => d.Lawyer)
                    .WithMany(p => p.AdvisoryLawyers)
                    .HasForeignKey(d => d.LawyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Advisory__Lawyer__173876EA");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingDate).HasColumnType("datetime");

                entity.Property(e => e.PayDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerCase)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerCaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Custome__286302EC");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Custome__29572725");
            });

            modelBuilder.Entity<CaseItem>(entity =>
            {
                entity.ToTable("CaseItem");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EventDate).HasColumnType("datetime");

                entity.Property(e => e.ImageUrl)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.CustomerCase)
                    .WithMany(p => p.CaseItems)
                    .HasForeignKey(d => d.CustomerCaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CaseItem__Create__33D4B598");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<CategoryLawyer>(entity =>
            {
                entity.ToTable("CategoryLawyer");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryLawyers)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryL__Categ__1FCDBCEB");

                entity.HasOne(d => d.Lawyer)
                    .WithMany(p => p.CategoryLawyers)
                    .HasForeignKey(d => d.LawyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryL__Lawye__20C1E124");
            });

            modelBuilder.Entity<CategoryLawyerOffice>(entity =>
            {
                entity.ToTable("CategoryLawyerOffice");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoryLawyerOffices)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryL__Categ__1BFD2C07");

                entity.HasOne(d => d.LawyerOffice)
                    .WithMany(p => p.CategoryLawyerOffices)
                    .HasForeignKey(d => d.LawyerOfficeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CategoryL__Lawye__1CF15040");
            });

            modelBuilder.Entity<CustomerCase>(entity =>
            {
                entity.ToTable("CustomerCase");

                entity.Property(e => e.Description).HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.ToTable("Document");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Documents)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Document__Catego__239E4DCF");
            });

            modelBuilder.Entity<DocumentCase>(entity =>
            {
                entity.ToTable("DocumentCase");

                entity.HasOne(d => d.CustomerCase)
                    .WithMany(p => p.DocumentCases)
                    .HasForeignKey(d => d.CustomerCaseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DocumentC__Custo__300424B4");

                entity.HasOne(d => d.Document)
                    .WithMany(p => p.DocumentCases)
                    .HasForeignKey(d => d.DocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DocumentC__Docum__30F848ED");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.ToTable("Level");

                entity.Property(e => e.LevelName)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Slot>(entity =>
            {
                entity.ToTable("Slot");

                entity.Property(e => e.EndAt).HasColumnType("datetime");

                entity.Property(e => e.StartAt).HasColumnType("datetime");

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Slot__BookingId__2D27B809");

                entity.HasOne(d => d.Lawyer)
                    .WithMany(p => p.Slots)
                    .HasForeignKey(d => d.LawyerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Slot__LawyerId__2C3393D0");
            });

            modelBuilder.Entity<UserAccount>(entity =>
            {
                entity.ToTable("UserAccount");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location).HasMaxLength(100);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Website)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.LawyerOffice)
                    .WithMany(p => p.InverseLawyerOffice)
                    .HasForeignKey(d => d.LawyerOfficeId)
                    .HasConstraintName("FK__UserAccou__Lawye__1367E606");

                entity.HasOne(d => d.Level)
                    .WithMany(p => p.UserAccounts)
                    .HasForeignKey(d => d.LevelId)
                    .HasConstraintName("FK__UserAccou__Level__1273C1CD");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
