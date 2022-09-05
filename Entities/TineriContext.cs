using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace test2.Entities
{
    public class TineriContext : IdentityDbContext<User,Role,string,IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>,
        IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public DbSet<Tanar> Tineri { get; set; }
        public DbSet<Locatie> Locatie { get; set; }

        public DbSet<Activitate> Activitate { get; set; }
        public DbSet<PerioadaActivitate> PerioadaActivitate { get; set; }

        public DbSet<Tabela> Tabela { get; set; }
        //public TineriContext(DbContextOptions<TineriContext> options) : base(options) { }

        //pus in lab4
        //contextul cand e instantiat ia din optiunile din Startup
        public TineriContext(DbContextOptions<TineriContext> options) : base(options) { }

        //configurare inainte de Dependency Injection
        /*
         //l-am comentat in labul 4
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               // .UseLazyLoadingProxies()
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
                .UseSqlServer("Server=DESKTOP-40EQLI6\\SQLEXPRESS;Initial Catalog=voluntariat;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        }
        */

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tanar>()
                .HasOne(a => a.Locatie)
                .WithOne(aa => aa.Tineri)
                .HasForeignKey<Locatie>(c => c.TanarId);
            
            builder.Entity<Activitate>()
                .HasMany(a => a.PerioadaActivitate) //One to many
                .WithOne(b => b.Activitate);
            
            builder.Entity<Tabela>()
                .HasKey(c => new { c.IdTanar, c.IdActivitate });
            
            builder.Entity<Tabela>()
                .HasOne<Tanar>(a => a.Tineri) //tabela are un tanar
                .WithMany(b => b.TanarActivitate) //care are mai multe activitati
                .HasForeignKey(c => c.IdTanar);

            builder.Entity<Tabela>()
                .HasOne<Activitate>(a => a.Activitate) //tabela are o activitate
                .WithMany(b => b.TanarActivitate)
                .HasForeignKey(c => c.IdActivitate);

        }
    }
}
