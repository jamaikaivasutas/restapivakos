using System.Text;
using Snooker;

var fileData = await File.ReadAllLinesAsync("snooker.txt", Encoding.UTF7);

var players = new List<Player>();

foreach (var line in fileData)
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
Console.WriteLine($"A világranglistán {playersOnWorldList} versenyző szerepel");

//Versenyzők átlag nyereménye
var averageWinnings = players.Average(x => x.Winnings);
Console.WriteLine($"A versenyzők átlagosan {Math.Round(averageWinnings, 2)} fontot kerestek");

//Határozza meg és írassa ki a legjobban kereső kínai versenyző adatait!
//var highestChineseWinnings = players.Where(x => x.Country == "Kína").Max(x => x.Winnings);


var highestEarningChinesePlayer = players.Where(x => x.Country == "Kína" && x.Winnings == players.Max(x => x.Winnings))
                                         .ToList();

Console.WriteLine($"{highestEarningChinesePlayer}");
//Console.WriteLine(highestEarningChinesePlayer);

