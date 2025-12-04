using System.Text;
using Calls;

var fileData = await File.ReadAllLinesAsync("hivasok.txt", Encoding.UTF8);

var calls = new List<Call>();

foreach (var line in fileData)
{
    var data = line.Split(' ');
    calls.Add(new Call
    {
        StartHour = int.Parse(data[0]),
        StartMinute = int.Parse(data[1]),
        StartSecond = int.Parse(data[2]),
        EndHour = int.Parse(data[3]),
        EndMinute = int.Parse(data[4]),
        EndSecond = int.Parse(data[5]),
        PhoneNumber = int.Parse(data[6])
    });
}

foreach(var call in calls)
{
    Console.WriteLine($"Hívás kezdete: {call.StartHour}:{call.StartMinute}:{call.StartSecond}, " +
                      $"Hívás vége: {call.EndHour}:{call.EndMinute}:{call.EndSecond}, " +
                      $"Telefonszám: {call.PhoneNumber}");
}