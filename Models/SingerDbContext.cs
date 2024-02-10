using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_SQLServer.Models;

public partial class SingerDbContext : DbContext
{
    public SingerDbContext()
    {
    }

    public SingerDbContext(DbContextOptions<SingerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Singer> Singers { get; set; }

    public virtual DbSet<Song> Songs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local); DataBase=SingerDB; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Singer>(entity =>
        {
            entity.HasKey(e => e.Singerid).HasName("PK__Singer__0E5C17720DFEED62");

            entity.ToTable("Singer");

            entity.Property(e => e.NameSinger)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Song>(entity =>
        {
            entity.HasKey(e => e.Songid).HasName("PK__SONG__12ECD2BF7C21CFC8");

            entity.ToTable("SONG");

            entity.Property(e => e.NameSong)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
