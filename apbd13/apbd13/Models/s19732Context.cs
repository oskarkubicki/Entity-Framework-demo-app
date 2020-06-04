using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace apbd13.Models
{
    public partial class s19732Context : DbContext
    {
        public s19732Context()
        {
        }

        public s19732Context(DbContextOptions<s19732Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Confectionery> Confectionery { get; set; }
        public virtual DbSet<ConfectioneryOrder> ConfectioneryOrder { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Enrollment> Enrollment { get; set; }
        public virtual DbSet<Movie> Movie { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Perscriptions> Perscriptions { get; set; }
        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Studies> Studies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s19732;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Confectionery>(entity =>
            {
                entity.HasKey(e => e.IdConfectionery)
                    .HasName("Confectionery_pk");

                entity.Property(e => e.IdConfectionery).ValueGeneratedNever();

                entity.Property(e => e.NAme)
                    .IsRequired()
                    .HasColumnName("nAME")
                    .HasMaxLength(200);

                entity.Property(e => e.Typ)
                    .IsRequired()
                    .HasMaxLength(40);
            });

            modelBuilder.Entity<ConfectioneryOrder>(entity =>
            {
                entity.HasKey(e => new { e.IdConfection, e.IdOrder })
                    .HasName("Confectionery_Order_pk");

                entity.ToTable("Confectionery_Order");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdConfectionNavigation)
                    .WithMany(p => p.ConfectioneryOrder)
                    .HasForeignKey(d => d.IdConfection)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Confectionery_Order_Confectionery");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.ConfectioneryOrder)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Confectionery_Order_Order");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdClient)
                    .HasName("Customer_pk");

                entity.Property(e => e.IdClient).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(60);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmployee)
                    .HasName("Employee_pk");

                entity.Property(e => e.IdEmployee).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(40);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(60);
            });

            modelBuilder.Entity<Enrollment>(entity =>
            {
                entity.HasKey(e => e.IdEnrollment)
                    .HasName("Enrollment_pk");

                entity.Property(e => e.IdEnrollment).ValueGeneratedNever();

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.IdStudyNavigation)
                    .WithMany(p => p.Enrollment)
                    .HasForeignKey(d => d.IdStudy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Enrollment_Studies");
            });

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("Order_pk");

                entity.Property(e => e.IdOrder).ValueGeneratedNever();

                entity.Property(e => e.DateAccepted).HasColumnType("datetime");

                entity.Property(e => e.DateFinished).HasColumnType("datetime");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasColumnName("notes")
                    .HasMaxLength(255);

                entity.HasOne(d => d.IdClientNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdClient)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Customer");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdEmployee)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Order_Employee");
            });

            modelBuilder.Entity<Patients>(entity =>
            {
                entity.HasKey(e => e.IdPatient)
                    .HasName("Patient_PK");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Perscriptions>(entity =>
            {
                entity.HasKey(e => e.IdPerscription)
                    .HasName("Percription_PK");

                entity.HasIndex(e => e.IdPatient);

                entity.Property(e => e.Date).HasDefaultValueSql("('2020-05-21T17:00:21.1052872+02:00')");

                entity.HasOne(d => d.IdPatientNavigation)
                    .WithMany(p => p.Perscriptions)
                    .HasForeignKey(d => d.IdPatient)
                    .HasConstraintName("Persciption_Patient_FK");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IndexNumber)
                    .HasName("Student_pk");

                entity.Property(e => e.IndexNumber).HasMaxLength(100);

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdEnrollmentNavigation)
                    .WithMany(p => p.Student)
                    .HasForeignKey(d => d.IdEnrollment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Student_Enrollment");
            });

            modelBuilder.Entity<Studies>(entity =>
            {
                entity.HasKey(e => e.IdStudy)
                    .HasName("Studies_pk");

                entity.Property(e => e.IdStudy).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
