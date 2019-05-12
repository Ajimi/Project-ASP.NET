using Data.Conventions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Context:DbContext
    {

        public Context():base("name=BD")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Add<KeyConvention>();


            // Configuration
            modelBuilder.Entity<Candidat>()
                .HasMany<Formation>(s => s.Formations)
                .WithMany(c => c.Candidats)
                .Map(cs =>
                {
                    cs.ToTable("Participation");
                });


            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Formation> Formations { get; set; }
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<Formateur> Formateurs { get; set; }

    }
}
