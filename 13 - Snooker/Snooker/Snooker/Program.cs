using System.Text;
using System.Linq;
using Snooker;

var fileData = await File.ReadAllLinesAsync("snooker.txt", Encoding.UTF7);

var players = new List<Player>();

foreach (var line in fileData.Skip(1))
{
    var data = line.Split(';');
    players.Add(new Player
    {
        Finish = int.Parse(data[0]),
        Name = data[1],
        Country = data[2],
        Winnings = int.Parse(data[3])
    });
}


//Írassa ki hogy hány versenyző szerepel a világranglistán!
var playersOnWorldList = players.Count;
Console.WriteLine($"3. feladat: A világranglistán {playersOnWorldList} versenyző szerepel");

//Versenyzők átlag nyereménye
var averageWinnings = players.Average(x => x.Winnings);
Console.WriteLine($"4. feladat: A versenyzők átlagosan {Math.Round(averageWinnings, 2)} fontot kerestek");

//Határozza meg és írassa ki a legjobban kereső kínai versenyző adatait!
//var highestChineseWinnings = players.Where(x => x.Country == "Kína").Max(x => x.Winnings);

var maxChineseWinnings = players.Where(x => x.Country == "Kína").Max(x => x.Winnings);

var highestEarningChinesePlayer = players.Where(x => x.Country == "Kína" && x.Winnings == maxChineseWinnings)
                                         .ToList();

foreach(var data in highestEarningChinesePlayer)
{
    Console.WriteLine($"5. feladat: A legjobban kereső kínai játékos \n Helyezése: {data.Finish} \nNeve: {data.Name} \n Országa: {data.Country} \n Nyeresége: {(data.Winnings)*380} Ft");
}

//Határozza meg hogy van-e norvég játékos a versenyzők között!

var isThereNorvegian = players.Any(x => x.Country == "Norvégia");

if (isThereNorvegian)
{
    Console.WriteLine("6. feladat: A versenyzők között van Norvég játékos");
}
else
{
    Console.WriteLine("6. feladat: A versenyzők között nincs Norvég játékos");
}


//

var statsByCountry = players.GroupBy(x => x.Country)
                            .Select(x => $"{x.Key} - {x.Count()} fő")
                            .OrderBy(x => x);

foreach(var stat in statsByCountry)
{
    Console.WriteLine("7. feladat: Statisztika \n");
    Console.WriteLine(stat);
}

Console.ReadKey();

