using Microsoft.EntityFrameworkCore;
using Sport_App.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sport_App.Daten
{
    // GSOPizzaContext Klasse erbt von DbContext, einem Teil des Entity Frameworks
    internal class SportApp : DbContext
    {
        // DbSet-Eigenschaften repräsentieren Tabellen in der Datenbank
        // Jede Eigenschaft ist stark typisiert mit einer Modellklasse
        public DbSet<Nutzer> Nutzern { get; set; } = null!;
        public DbSet<Trainingsplan> Trainingsplaene { get; set; } = null!;
        public DbSet<Sportart> Sportarten { get; set; } = null!;
        public DbSet<TrainingsAufbau> TrainingsAufbauten { get; set; } = null!;

        // OnModelCreating-Methode wird verwendet, um das Modell und die Beziehungen mittels Fluent API zu konfigurieren
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definieren von Primärschlüsseln für jede Entität
            modelBuilder.Entity<Nutzer>().HasKey(k => k.Id);
            modelBuilder.Entity<Trainingsplan>().HasKey(b => b.Id);
            modelBuilder.Entity<Sportart>().HasKey(p => p.Id);
            modelBuilder.Entity<TrainingsAufbau>().HasKey(bd => bd.Id);

            // Immer die Basis-Methode aufrufen, um das Basisverhalten einzuschließen
            base.OnModelCreating(modelBuilder);
        }

        // OnConfiguring-Methode wird verwendet, um die Datenbankverbindung und andere Konfigurationen einzustellen
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Überprüfen, ob der optionsBuilder bereits konfiguriert ist, wenn nicht, konfigurieren
            if (!optionsBuilder.IsConfigured)
            {
                // Konfigurieren der Verwendung der SQLite-Datenbank mit dem angegebenen Verbindungsstring
                optionsBuilder.UseSqlite(@"Data Source=C:\Users\dmytro.d2\Source\Repos\demkodim\Sport-App-Projektarbeit-\Sport-App\Sport-App.db");
            }

            // Immer die Basis-Methode aufrufen, um das Basisverhalten einzuschließen
            base.OnConfiguring(optionsBuilder);
        }
    }
}