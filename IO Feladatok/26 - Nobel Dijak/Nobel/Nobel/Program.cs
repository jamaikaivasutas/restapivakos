
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Nobel;

var fileData = await File.ReadAllLinesAsync("nobel.csv", Encoding.UTF8);

var nobelList = new List<Nobels>();

foreach (var line in fileData.Skip(1))
{
    var data = line.Split(';');
    nobelList.Add(new Nobels()
    {
        Year = int.Parse(data[0]),
        Type = data[1],
        FirstName = data[2],
        LastName = data[3]
    });
}

//Határozza meg Arthur B. McDonald milyen díjat kapott

var arthurPrize = nobelList
    .FirstOrDefault(n => n.FirstName == "Arthur B." && n.LastName == "McDonald")?.Type;

Console.WriteLine($"3. feladat: Arthur B. McDonald {arthurPrize} típusú Nobel díjat kapott.");


//Határozza meg kik nyertek 2017ben irodalmi nobel dijat

var LiteratureWinners2017 = nobelList
    .Where(x => x.Year == 2017 && x.Type == "irodalmi")
    .Select(x => $"{x.FirstName} {x.LastName}")
    .ToList();

Console.WriteLine("4. feladat: ");
foreach(var winner in LiteratureWinners2017)
{
    Console.WriteLine($"\b{winner}");
}


//Határozza meg mely szervezetek kaptak béke Nobel dijat 1990től napjainkig
var peacePrizeSince1990 = nobelList.Where(x => x.Type == "béke" && x.Year >= 1990 && x.LastName == string.Empty).Select(x => $"{x.Year}: {x.FirstName}").ToList();

Console.WriteLine("5. feladat: ");
foreach(var peacePrizeWinner in peacePrizeSince1990)
{
    Console.WriteLine($"\b{peacePrizeWinner}");
}

//Curie díjasok

var CuriePrizes = nobelList.Where(x => x.LastName.Contains("Curie")).Select(x => $"{x.Year}: {x.FirstName} {x.LastName} ({x.Type})").ToList();

Console.WriteLine("6. feladat: ");
foreach (var curiePrize in CuriePrizes)
{
        Console.WriteLine($"\b{curiePrize}");
}


//Kategóriánként hány díjat osztottak ki

var prizeCountByType = nobelList
    .GroupBy(x => x.Type)
    .Select(x => new { Type = x.Key, Count = x.Count() })
    .ToList();

Console.WriteLine("7. feladat: ");
foreach (var prizeType in prizeCountByType)
{
    Console.WriteLine($"\b{prizeType.Type}: {prizeType.Count} db");
}

//Írassa ki az orvosi nóbel díjasokat a minta szerint az orvosi.txt állományba

var doctorPrizes = nobelList.Where(x => x.Type == "orvosi").Select(x => $"{x.Year}:{x.FirstName} {x.LastName}").ToList();

await File.WriteAllLinesAsync("orvosi.txt", doctorPrizes, Encoding.UTF8);
Console.WriteLine("8. feladat: orvosi.txt");

Console.ReadKey();