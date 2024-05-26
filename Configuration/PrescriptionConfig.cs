using APBD_Zadanie_6.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace APBD_Zadanie_6.Configuration
{
    public class PrescriptionConfig : IEntityTypeConfiguration<Prescription>
    {
        public void Configure(EntityTypeBuilder<Prescription> builder)
        {
            builder.HasKey(e => e.IdPrescription).HasName("Prescription_PK");
            builder.Property(e => e.IdPrescription).UseIdentityColumn();

            builder.Property(e => e.Date).IsRequired();
            builder.Property(e => e.DueDate).IsRequired();

            builder.HasOne(e => e.Patient)
                   .WithMany(p => p.Prescriptions)
                   .HasForeignKey(e => e.IdPatient)
                   .HasConstraintName("Prescription_Patient");

            builder.HasOne(e => e.Doctor)
                   .WithMany(d => d.Prescriptions)
                   .HasForeignKey(e => e.IdDoctor)
                   .HasConstraintName("Prescription_Doctor");

            var prescriptions = new List<Prescription>
            {
                new Prescription
                {
                    IdPrescription = 1,
                    Date = DateTime.Parse("2023-01-01"),
                    DueDate = DateTime.Parse("2023-02-01"),
                    IdPatient = 1,
                    IdDoctor = 1
                },
                new Prescription
                {
                    IdPrescription = 2,
                    Date = DateTime.Parse("2023-03-01"),
                    DueDate = DateTime.Parse("2023-04-01"),
                    IdPatient = 2,
                    IdDoctor = 2
                },
                new Prescription
                {
                    IdPrescription = 3,
                    Date = DateTime.Parse("2023-05-01"),
                    DueDate = DateTime.Parse("2023-06-01"),
                    IdPatient = 3,
                    IdDoctor = 3
                },
                new Prescription
                {
                    IdPrescription = 4,
                    Date = DateTime.Parse("2023-07-01"),
                    DueDate = DateTime.Parse("2023-08-01"),
                    IdPatient = 4,
                    IdDoctor = 4
                },
                new Prescription
                {
                    IdPrescription = 5,
                    Date = DateTime.Parse("2023-09-01"),
                    DueDate = DateTime.Parse("2023-10-01"),
                    IdPatient = 5,
                    IdDoctor = 5
                }
            };

            builder.HasData(prescriptions);
        }
    }
}
