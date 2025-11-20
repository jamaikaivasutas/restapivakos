using System.Text;
using System.Linq;
using VB;

var fileData = await File.ReadAllLinesAsync("vb2018.txt", Encoding.UTF8);

var matches = new List<Matches>();

foreach (var line in fileData.Skip(1))
{
    var data = line.Split(';');
    matches.Add(new Matches
    {
        City = data[0],
        Name = data[1],
        SecondName = data[2],
        Capacity = int.Parse(data[3])
    });
}


//Jelenítse meg a képernyőn hogy hány stadionban játszottak

Console.WriteLine($"3. feladat: Stadionok száma: {matches.Count}");


//Keresse meg a legkevesebb férőhellyel rendelkező stadiont és irassa ki a képernyőre

var leastCapacity = matches.Min(x => x.Capacity);
var leastCapacityStadium = matches.Where(x => x.Capacity == leastCapacity).ToList();

foreach (var stadium in leastCapacityStadium)
{
    Console.WriteLine($"4. feladat: A legkevesebb férőhely: \n Város: {stadium.City} \n Stadion neve: {stadium.Name} \n Férőhely: {stadium.Capacity}");
}

//Keresse meg a stadionok átlagos férőhelyét és kerekítse egy tizedesjegyre majd irja ki a kepernyore
var averageCapacity = matches.Average(x => x.Capacity);

Console.WriteLine($"5. feladat: Az átlag férőhely: {Math.Round(averageCapacity, 1)}");

//Számolja meg a két névvel is rendelkező stadionokat és irassa ki a kepernyore
var stadiumsWithTwoNames = matches.Where(x => x.SecondName != "n.a.").Count();

Console.WriteLine($"6. feladat: Két neven is ismert stadionok száma: {stadiumsWithTwoNames}");

//
Console.Write("7. feladat: Kérem a város nevét: ");
var cityName = Console.ReadLine();

var isVBCity = matches.Any(x => x.City == cityName);

if(isVBCity)
{
    Console.WriteLine("8. feladat: A megadott város VB helyszín");
}
else
{
    Console.WriteLine("8. feladat: A megadott város nem VB helyszín");
}