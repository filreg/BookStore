using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BookStore.Infrastructure.Mappings
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name).IsRequired().HasColumnType("varchar(150)");
            builder.HasMany(c => c.Books)
                .WithOne(b => b.Category)
                .HasForeignKey(builder => builder.CategoryId);
            builder.ToTable("Categories");
           
        }
    }
}
