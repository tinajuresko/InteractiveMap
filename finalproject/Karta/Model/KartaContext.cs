using System;
using System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;


namespace Karta.Model;

public partial class KartaContext : DbContext
{
    //private readonly IConfiguration _configuration;
    
    public KartaContext(DbContextOptions<KartaContext> options)
        : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            /* var connectionString = _configuration.GetConnectionString("MyPostgreSQLDatabase");
             optionsBuilder.UseNpgsql(connectionString);*/
           // var connectionString = _configuration.GetConnectionString("MyPostgreSQLDatabase");
            // optionsBuilder.UseNpgsql(connectionString);
            //var connectionString = _configuration.GetConnectionString("MyPostgreSQLDatabase");
            
           


        }
    }

    public virtual DbSet<Autocesta> Autocesta { get; set; }
    public virtual DbSet<Dionica> Dionica { get; set; }
    public virtual DbSet<Dogadaj> Dogadaj { get; set; }
     public virtual DbSet<Koncesionar> Koncesionar { get; set; }
    public virtual DbSet<NaplatnaPostaja> NaplatnaPostaja { get; set; }
    public virtual DbSet<Odmoriste> Odmoriste { get; set; }
    public virtual DbSet<PrateciSadrzaj> PrateciSadrzaj { get; set; }
     public virtual DbSet<VrstaPratecegSadrzaj> VrstaPratecegSadrzaj { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Autocesta>(entity =>
        {
            entity.HasKey(e => e.IdAutocesta);

            entity.Property(e => e.NazivAutocesta)
                .IsRequired()
                .HasMaxLength(5)
                .IsUnicode(false);

            entity.HasOne(d => d.IdKoncesionarNavigation).WithMany(p => p.Autocesta)
                .HasForeignKey(d => d.IdKoncesionar)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Autocesta_IdKoncesionar_fkey");
        });

     

        modelBuilder.Entity<Dionica>(entity =>
        {
            entity.HasKey(e => e.IdDionica);

            entity.Property(e => e.Kilometraža).HasColumnType("numeric(10, 3)").IsRequired();
            entity.Property(e => e.NazivDionica)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);

            entity.HasOne(d => d.IdAutocestaNavigation).WithMany(p => p.Dionica)
                .HasForeignKey(d => d.IdAutocesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dionica_IdAutocesta_fkey");
        });

        modelBuilder.Entity<Dogadaj>(entity =>
        {
            entity.HasKey(e => e.IdDogadaj);

            entity.Property(e => e.IdDogadaj).HasColumnName("IdDogadaj");
            entity.Property(e => e.IdDionica).HasColumnName("IdDionica").IsRequired();
            entity.Property(e => e.MeteoroloskiUvjeti).IsRequired()
                .HasMaxLength(40) 
                .IsUnicode(false)
                .HasColumnName("MeteoroloskiUvjeti");
            entity.Property(e => e.OpisDogadaja).IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("OpisDogadaja");
            entity.Property(e => e.VrijemeDogadaja).IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("VrijemeDogadaja");
            entity.Property(e => e.Coordinates)
                .HasColumnName("Coordinates");

            entity.HasOne(d => d.IdDionicaNavigation).WithMany(p => p.Dogadaj) 
                .HasForeignKey(d => d.IdDionica)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Dogadaj_IdDionica_fkey");
        });

      
        modelBuilder.Entity<Koncesionar>(entity =>
        {
            entity.HasKey(e => e.IdKoncesionar);

            entity.Property(e => e.Adresa)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Fax)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.NazivKoncesionar)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.NazivMjesto)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.Oibkoncesionar)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("OIBKoncesionar");
            entity.Property(e => e.Tel)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.TipKoncesionar)
                .IsRequired()
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.WebUrl)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("WebURL");
        });

       

        modelBuilder.Entity<NaplatnaPostaja>(entity =>
        {
            entity.HasKey(e => e.IdNaplatnaPostaja);

            entity.Property(e => e.Kontakt)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.NaplatnaPostajaKoordinateEw)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NaplatnaPostajaKoordinateEw");
            entity.Property(e => e.NaplatnaPostajaKoordinateNs)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NaplatnaPostajaKoordinateNs");
            entity.Property(e => e.NazivNaplatnaPostaja)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.IdAutocesta).HasColumnName("IdAutocesta");


            entity.HasOne(d => d.IdAutocestaNavigation).WithMany(p => p.NaplatnaPostaja)
                .HasForeignKey(d => d.IdAutocesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("naplatnapostaja_idautocesta_fkey");
        });

      

        modelBuilder.Entity<Odmoriste>(entity =>
        {
            entity.HasKey(e => e.IdOdmoriste);

            entity.Property(e => e.NazivOdmoriste)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false);
            entity.Property(e => e.OdmoristeKoordinateEw)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("OdmoristeKoordinateEw");
            entity.Property(e => e.OdmoristeKoordinateNs)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("OdmoristeKoordinateNs");
            entity.Property(e => e.Smjer)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false);
                

            entity.HasOne(d => d.IdAutocestaNavigation).WithMany(p => p.Odmoriste)
                .HasForeignKey(d => d.IdAutocesta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("odmoriste_idautocesta_fkey");
        });

    

        

        modelBuilder.Entity<PrateciSadrzaj>(entity =>
        {
            entity.HasKey(e => e.IdPratecegSadrzaja);

        
            entity.Property(e => e.NazivPratecegSadrzaja)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.RadnoVrijemeOd).IsRequired();
            entity.Property(e => e.RadnoVrijemeDo).IsRequired();

            entity.HasOne(d => d.IdOdmoristeNavigation).WithMany(p => p.PrateciSadrzaj)
                .HasForeignKey(d => d.IdOdmoriste)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pratecisadrzaj_idodmoriste_fkey");

            entity.HasOne(d => d.IdVrstaPratecegSadrzajaNavigation).WithMany(p => p.PrateciSadrzaj)
                .HasForeignKey(d => d.IdVrstaPratecegSadrzaja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("pratecisadrzaj_idvrstapratecegsadrzaja_fkey");
        });

      

       

        modelBuilder.Entity<VrstaPratecegSadrzaj>(entity =>
        {
            entity.HasKey(e => e.IdVrstaPratecegSadrzaja).HasName("PK_VrstaPratecegSadrzaja");

            entity.HasIndex(e => e.NazivVrstePratecegSadrzaja, "UNIQUE_NazivVrstePratecegSadrzaja").IsUnique();

            entity.Property(e => e.NazivVrstePratecegSadrzaja)
                .IsRequired()
                .HasMaxLength(120)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
