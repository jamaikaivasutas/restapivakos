using EU_Tagallamok;
using System.Text;

var fileData = await File.ReadAllLinesAsync("EUcsatlakozas.txt", Encoding.UTF8);

var members = new List<MemberState>();

foreach(var line in fileData)
{
    var data = line.Split(';');
    members.Add(new MemberState
    {
        Name = data[0],
        JoinDate = DateTime.Parse(data[1]),
    });
}

//Határozza meg hogy hány tagállama volt az Eunak 2018ban

var count2018 = members.Count(x => x.JoinDate.Year <= 2018);

Console.WriteLine($"1.feladat: 2018-ban {count2018} darab tagállama volt az EUnak\n");

//Határozza meg a 2007ben csatlakozott országok számát

var count2007 = members.Count(x => x.JoinDate.Year == 2007);    

Console.WriteLine($"2.feladat: 2007-ben csatlakozott országok száma: {count2007}\n");

//Határozza meg Magyarország csatlakozásának dátumát

var hungaryJoinDate = members.First(x => x.Name == "Magyarorsz�g").JoinDate;
var hungaryDateOnly = DateOnly.FromDateTime(hungaryJoinDate);

Console.WriteLine($"3.feladat Magyarország csatlakozásának ideje: {hungaryDateOnly}\n");

//Határozza meg hogy Magyarország májusban csatlakozott-e

var didJoinInMay = members.Any(x => x.JoinDate.Month == 5 && x.Name == "Magyarorsz�g\n"); 

if (didJoinInMay)
{
    Console.WriteLine("4.feladat: A csatlakozás májusban történt\n");
} else
{
    Console.WriteLine("4.feladat: A csatlakozás nem májusban történt\n");
}

//Határozza meg a legutoljára csatlakozott ország nevét

var lastJoin = members.OrderByDescending(x => x.JoinDate).First();

Console.WriteLine($"5.feladat A legutoljára csatlakozott ország: {lastJoin.Name}\n");

//Készítsen évek szerinti statisztikát arról hogy hányan csatlakoztak egyes években

var stats = members.GroupBy(x => x.JoinDate.Year)
                   .Select(x => $"{x.Key} - {x.Count()} ország")
                   .OrderBy(x => x);

Console.WriteLine("6.feladat: Statisztika");
foreach (var stat in stats)
{
    Console.WriteLine(stat);
}

Console.ReadKey();


