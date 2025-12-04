using Roplabda;
using System.Text;


var fileData = await File.ReadAllLinesAsync("adatok.txt", Encoding.UTF7);

var players = new List<Volleyball>();

foreach (var line in fileData)
{
    var data = line.Split('\t');
    players.Add(new Volleyball
    {
        Name = data[0],
        Height = int.Parse(data[1]),
        Post = data[2],
        Nationality = data[3],
        Team = data[4],
        Country = data[5]
    });
}


//Írassuk ki az összes adatot
Console.WriteLine("Első feladat: ");
foreach(var player in players)
{
    Console.WriteLine(player.ToFullString());
}

//Szedjük ki az ütő játékosokat az uto.txt állományba
var hitters = fileData.Where(x => x.Contains("ütõ"));
await File.WriteAllLinesAsync("uto.txt", hitters, Encoding.UTF8);

//A csapattagok.txt állományba mentsük a csapatokat és a hozzájuk tartozó játékosokat a következő formában:
//Telekom Baku: Yelizaveta Mammadova,Yekaterina Gamova,

var teams = players.GroupBy(x => x.Team)
                   .Select(x => $"{x.Key}: {string.Join(",", x.Select(x => x.Name))},");

await File.WriteAllLinesAsync("csapattagok.txt", teams, Encoding.UTF8);

//Rendezzük a játékosokat magasság szerint növekvő sorrendbe és a magaslatok.txt állományba mentsük.

var playersByHeightAscending = players.OrderBy(x => x.Height)
                                      .Select(x => x.ToFullString());

await File.WriteAllLinesAsync("magaslatok.txt", playersByHeightAscending, Encoding.UTF8);

//Mutassok be a nemzetisegek.txt állományba, hogy mely nemzetiségek képvesltetik magukat a röplabdavilágban mint játékosok és milyen számban.

var nationalities = players.GroupBy(x => x.Nationality)
                           .Select(x => $"{x.Key}: {x.Count()}");

await File.WriteAllLinesAsync("nemzetisegek.txt", nationalities, Encoding.UTF8);

//atlagnalmagasabbak.txt állományba keressük azon játékosok nevét és magasságát akik magasabbak mint az „adatbázisban” szereplő játékosok átlagos magasságánál.

var tallerThanAverage = players.Where(x => x.Height > players.Average(x => x.Height))
                               .Select(x => x.ToFullString());

await File.WriteAllLinesAsync("atlagnalmagasabbak.txt", tallerThanAverage, Encoding.UTF8);

//Állítsa növekvő sorrendbe a posztok sszerint a játékosok össz magasságát

var sumOfHeightByPost = players.GroupBy(x => x.Post)
                               .Select(x => $"{x.Key}: {x.Sum(x => x.Height)}");

//Egy szöveges állományba, „alacsonyak.txt” keresse ki a játékosok átlagmagasságától alacsonyabb játékosokat. Az állomány tartalmazza a játékosok nevét,  magasságát és hogy mennyivel alacsonyabbak az átlagnál, 2 tizedes pontossággal.

var shortPeople = players.Where(x => x.Height < players.Average(x => x.Height))
                         .Select(x => $"{x.Name} {x.Height} {Math.Round(players.Average(x => x.Height) - x.Height, 2)}");

await File.WriteAllLinesAsync("alacsonyak.txt", shortPeople, Encoding.UTF8);

Console.ReadKey();

