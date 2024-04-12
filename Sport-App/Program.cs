using Microsoft.EntityFrameworkCore;
using Sport_App.Daten;
using Sport_App.Model;
using System.Text;

SportAppContext dbContext = new SportAppContext();

Nutzer nutzer_1 = new Nutzer()
{
     Id = 1,
     Name = "John",
     Alter = 18,
     Gewicht = 70
};

dbContext.Nutzern.Add(nutzer_1);
await dbContext.SaveChangesAsync();

Sportart sportart_1 = new Sportart()
{
    Id = 100,
    Name = "Liegestuetze"

};
dbContext.Sportarten.Add(sportart_1);
await dbContext.SaveChangesAsync();

Sportart sportart_2 = new Sportart()
{
    Id = 101,
    Name = "Sit-up"

};
dbContext.Sportarten.Add(sportart_2);
await dbContext.SaveChangesAsync();

Sportart sportart_3 = new Sportart()
{
    Id = 103,
    Name = "Klimmzug"

};
dbContext.Sportarten.Add(sportart_3);
await dbContext.SaveChangesAsync();

Trainingsplan trainingsplan_1 = new Trainingsplan()
{
    Id = 1,
    Nutzer = nutzer_1,
   
};
dbContext.Trainingsplaene.Add(trainingsplan_1);
await dbContext.SaveChangesAsync();

TrainingsAufbau trainingsaufbau_1 = new TrainingsAufbau()
{
    Id = 1,
    Anzahl = 1,
    Sportart = sportart_1,
  


};
dbContext.TrainingsAufbauten.Add(trainingsaufbau_1);
await dbContext.SaveChangesAsync();

await AlleNutzernAnzeigen(dbContext);

static async Task AlleNutzernAnzeigen(SportAppContext dbContext)
{
    var alleNutzern = await dbContext.Nutzern
                                    .ToListAsync();
    Console.WriteLine("-----------------------------------------");
    Console.WriteLine("Alle Nutzern:");
    foreach (var nutzer in alleNutzern)
    {
        Console.WriteLine($"NutzerId: {nutzer.Id}, Name: {nutzer.Name}, Alter: {nutzer.Alter}, Gewicht: {nutzer.Gewicht} ");
    }
}
Console.WriteLine("1");

