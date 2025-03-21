﻿using ArgusEyesApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArgusEyesApi.Data
{
    public class KundenDBContext :DbContext
    {
        public KundenDBContext(DbContextOptions<KundenDBContext> option): base(option)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KundenDaten>().HasData(
                   new KundenDaten
                   {
                       Id = 1,
                       Vorname = "Omar",
                       Nachname = "Tamr",
                       Geburtsdatum = new DateTime(1994,1,1),
                       Alter = 25,
                       Strasse = "hamburgerstr",
                       Hausnummer = 15,
                       Plz = 12331,
                       
                   },


                   new KundenDaten
                   {
                       Id = 2,
                       Vorname = "Rudi",
                       Nachname = "HH",
                       Geburtsdatum = new DateTime(1994, 1, 1),
                       Alter = 25,
                       Strasse = "hamburgerstr",
                       Hausnummer = 15,
                       Plz = 12331,
                       
                   }

               );
        }

        public DbSet<KundenDaten> KundenDaten { get; set; }
        public DbSet<KundenImagesDaten> KundenImagesDaten { get; set; }
        public DbSet<Metadaten> Metadaten { get; set; }
        public DbSet<PunktKoordinaten> PunktKoordinaten { get; set; }


    }
    
}
