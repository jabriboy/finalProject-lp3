using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using finalProject_lp3.MODEL;

namespace finalProject_lp3.DAL.DBContext;

public partial class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext()
    {
    }

    public DbContext(DbContextOptions<DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chat> Chats { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\jabri\\source\\repos\\finalProject-lp3\\finalProject-lp3.DAL\\database\\database.mdf;Integrated Security=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Chat__3214EC07BF56A299");

            entity.ToTable("Chat");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdUser1).HasColumnName("id_user1");
            entity.Property(e => e.IdUser2).HasColumnName("id_user2");
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Messages__3214EC0716B5B039");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IdChat).HasColumnName("id_chat");
            entity.Property(e => e.IdUser).HasColumnName("id_user");
            entity.Property(e => e.Message1)
                .IsUnicode(false)
                .HasColumnName("message");

            entity.HasOne(d => d.IdChatNavigation).WithMany(p => p.Messages)
                .HasForeignKey(d => d.IdChat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Messages__id_cha__3A81B327");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC076A2C99D4");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Password)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
