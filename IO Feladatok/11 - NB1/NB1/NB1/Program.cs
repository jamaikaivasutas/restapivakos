
using NB1;
using System.Text;

var fileData = await File.ReadAllLinesAsync("adatok.txt", Encoding.UTF8);

var players = new List<Player>();

foreach (var line in fileData)
{
    var data = line.Split('\t');
    players.Add(new Player()
    {
        ClubName = data[0],
        PlayerNumber = int.Parse(data[1]),
        FirstName = data[2],
        LastName = data[3],
        DateOfBirth = DateTime.Parse(data[4]),
        IsHungarianCitizen = bool.Parse(data[5]),
        IsForeignCitizen = bool.Parse(data[6]),
        PayInThousand = int.Parse(data[7]),
        Post = data[8]
    });
}

//Kapusokon kívül mindenki mezőnyjátékos, keresse ki a legidősebb mezőnyjátékost



var oldestFielder = players.OrderBy(x => x.DateOfBirth)
                           .First();

Console.WriteLine(oldestFielder.ToFullString());




Console.ReadKey();