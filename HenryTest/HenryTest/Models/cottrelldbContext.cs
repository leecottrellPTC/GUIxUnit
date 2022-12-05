using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HenryTest.Models
{
    public partial class cottrelldbContext : DbContext
    {
        public cottrelldbContext()
        {
        }

        public cottrelldbContext(DbContextOptions<cottrelldbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookandcost> Bookandcosts { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookandcost>(entity =>
            {
                entity.HasKey(e => e.Bookcode)
                    .HasName("PK__bookandc__8913FFF9232716A2");

                entity.ToTable("bookandcost");

                entity.Property(e => e.Bookcode)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("bookcode")
                    .IsFixedLength();

                entity.Property(e => e.Price)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("price");

                entity.Property(e => e.Title)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("title")
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("type")
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
