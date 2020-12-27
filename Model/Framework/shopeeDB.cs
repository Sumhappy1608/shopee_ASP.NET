namespace Model.Framework
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class shopeeDB : DbContext
    {
        public shopeeDB()
            : base("name=shopeeDB")
        {
        }

        public virtual DbSet<HANGHOA> HANGHOAs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.MAHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.LOAIHANGHOA)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.HHFlag)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HANGHOA>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);
        }
    }
}
