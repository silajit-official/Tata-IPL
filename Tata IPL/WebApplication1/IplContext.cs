using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1;

public partial class IplContext : DbContext
{
    public IplContext()
    {
    }

    public IplContext(DbContextOptions<IplContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MatchDetail> MatchDetails { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    public virtual DbSet<TeamMatch> TeamMatches { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=IPL;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MatchDetail>(entity =>
        {
            entity.HasKey(e => e.MdId);

            entity.ToTable("MATCH_DETAILS");

            entity.Property(e => e.MdId).HasColumnName("MD_ID");
            entity.Property(e => e.FirstTeamBat).HasColumnName("FIRST_TEAM_BAT");
            entity.Property(e => e.MdTmId).HasColumnName("MD_TM_ID");
            entity.Property(e => e.PlayerOfTheMatch)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PLAYER_OF_THE_MATCH");
            entity.Property(e => e.WinByRuns).HasColumnName("WIN_BY_RUNS");
            entity.Property(e => e.WinByWickets).HasColumnName("WIN_BY_WICKETS");

            entity.HasOne(d => d.FirstTeamBatNavigation).WithMany(p => p.MatchDetails)
                .HasForeignKey(d => d.FirstTeamBat)
                .HasConstraintName("FK__MATCH_DET__FIRST__5070F446");

            entity.HasOne(d => d.MdTm).WithMany(p => p.MatchDetails)
                .HasForeignKey(d => d.MdTmId)
                .HasConstraintName("FK__MATCH_DET__MD_TM__4F7CD00D");
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.Pid).HasName("PK__PLAYER__C5775520F4F3EAC4");

            entity.ToTable("PLAYER");

            entity.Property(e => e.Pid).HasColumnName("PID");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.PTid).HasColumnName("P_TID");

            entity.HasOne(d => d.PT).WithMany(p => p.Players)
                .HasForeignKey(d => d.PTid)
                .HasConstraintName("FK__PLAYER__P_TID__4E88ABD4");
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.Tid).HasName("PK_PRIMARY");

            entity.ToTable("TEAM");

            entity.Property(e => e.Tid).HasColumnName("TID");
            entity.Property(e => e.Draw).HasColumnName("DRAW");
            entity.Property(e => e.Lose).HasColumnName("LOSE");
            entity.Property(e => e.Points).HasColumnName("POINTS");
            entity.Property(e => e.TeamName)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TEAM_NAME");
            entity.Property(e => e.Win).HasColumnName("WIN");
        });

        modelBuilder.Entity<TeamMatch>(entity =>
        {
            entity.HasKey(e => e.Tmid);

            entity.ToTable("TEAM_MATCH");

            entity.Property(e => e.Tmid).HasColumnName("TMID");
            entity.Property(e => e.PlayedOn)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("PLAYED_ON");
            entity.Property(e => e.Team1).HasColumnName("TEAM1");
            entity.Property(e => e.Team2).HasColumnName("TEAM2");

            entity.HasOne(d => d.Team1Navigation).WithMany(p => p.TeamMatchTeam1Navigations)
                .HasForeignKey(d => d.Team1)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TEAM_MATCH");

            entity.HasOne(d => d.Team2Navigation).WithMany(p => p.TeamMatchTeam2Navigations)
                .HasForeignKey(d => d.Team2)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TEAM2_MATCH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
