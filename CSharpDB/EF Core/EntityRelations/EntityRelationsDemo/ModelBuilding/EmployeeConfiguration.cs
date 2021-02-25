using FluentApiDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiDemo.ModelBuilding
{
    class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            builder
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .Ignore(x => x.FullName);

            builder
                .Property(x => x.StartWorkDate)
                .HasColumnName("StartedOn")
                .HasColumnType("date"); //avoid it

            builder
                .HasOne(x => x.Department) //required
                .WithMany(x => x.Employees)//optional (inverse prop)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
