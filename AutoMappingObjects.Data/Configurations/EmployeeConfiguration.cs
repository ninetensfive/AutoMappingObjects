using System;
using Microsoft.EntityFrameworkCore;
using AutoMappingObjects.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AutoMappingObjects.Data.Configurations
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder
                .Property(e => e.FirstName)                
                .IsRequired(true);

            builder
                .Property(e => e.LastName)
                .IsRequired(true);

            builder
                .Property(e => e.Salary)
                .IsRequired(true);
        }
    }
}
