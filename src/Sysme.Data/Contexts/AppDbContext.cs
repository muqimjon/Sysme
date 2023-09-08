using Microsoft.EntityFrameworkCore;
using Sysme.Domain.Entities.Appointments;
using Sysme.Domain.Entities.Doctors;
using Sysme.Domain.Entities.Employees;
using Sysme.Domain.Entities.Hospitals;
using Sysme.Domain.Entities.Patients;
using Sysme.Domain.Entities.Schedules;

namespace Sysme.Data.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Patient> Patients { get; set; }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Hospital> Hospitals { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Schedule> Schedules { get; set; }
    public DbSet<Employee> Employees { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Appointment>()
            .HasOne(d => d.Doctor)
            .WithMany(a => a.Appointments)
            .HasForeignKey(d => d.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Schedule>()
            .HasOne(d => d.Doctor)
            .WithMany(s => s.Schedules)
            .HasForeignKey(d => d.DoctorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Doctor>()
            .HasOne(h => h.Hospital)
            .WithMany(d => d.Doctors)
            .HasForeignKey(h => h.HospitalId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Appointment>()
            .Property(d => d.Price)
            .HasColumnType("decimal(18,2)");
    }
}
