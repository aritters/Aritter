﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ritter.Samples.Domain;
using Ritter.Samples.Domain.ValueObjects;

namespace Ritter.Samples.Infra.Data.Builders
{
    public static class EmployeeBuilderExtensions
    {
        public static void BuildEmployee(this EntityTypeBuilder<Employee> entity)
        {
            entity.ToTable("Employee");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("employee_id")
                .IsRequired();

            entity.OwnsOne(p => p.Name, name =>
            {
                name.Property(p => p.FirstName)
                    .HasColumnName("first_name")
                    .HasMaxLength(50)
                    .IsRequired();

                name.Property(p => p.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsRequired();
            });

            entity.Property(p => p.Cpf)
                .HasColumnName("cpf")
                .HasMaxLength(11)
                .IsRequired();

            entity.Property(p => p.Uid)
                .HasColumnName("uid")
                .IsRequired();
        }
    }
}