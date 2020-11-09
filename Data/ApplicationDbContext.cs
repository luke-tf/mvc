using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Desafio_MVC.Models;

namespace Desafio_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Gft> Gfts { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
        public DbSet<Tecnologia> Tecnologias { get; set; }
        public DbSet<Funcionario_Tecnologia> FuncTecs { get; set; }
        public DbSet<Vaga_Tecnologia> VagaTecs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario_Tecnologia>()
                .HasKey(ft => new { ft.Funcionario_Id, ft.Tecnologia_Id });
            modelBuilder.Entity<Funcionario_Tecnologia>()
                .HasOne(p => p.Funcionario)
                .WithMany(x => x.FuncTecs)
                .HasForeignKey(y => y.Funcionario_Id);
            modelBuilder.Entity<Funcionario_Tecnologia>()
                .HasOne(p => p.Tecnologia)
                .WithMany(x => x.FuncTecs)
                .HasForeignKey(y => y.Tecnologia_Id);

            modelBuilder.Entity<Vaga_Tecnologia>()
            .HasKey(vt => new { vt.Vaga_Id, vt.Tecnologia_Id });
            modelBuilder.Entity<Vaga_Tecnologia>()
                .HasOne(p => p.Vaga)
                .WithMany(x => x.VagaTecs)
                .HasForeignKey(y => y.Vaga_Id);
            modelBuilder.Entity<Vaga_Tecnologia>()
                .HasOne(p => p.Tecnologia)
                .WithMany(x => x.VagaTecs)
                .HasForeignKey(y => y.Tecnologia_Id);

            base.OnModelCreating(modelBuilder);
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {}
    }
}
