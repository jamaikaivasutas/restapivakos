using System.Text;

var fileData = await File.ReadAllLinesAsync("adatok.txt", Encoding.UTF8);

var books = new List<Book>(); 

foreach(var line in fileData)
{
   var data = line.Split('\t');
    books.Add(new Book
    {
        FirstName = data[0],
        LastName = data[1],
        Birthday = DateTime.Parse(data[2]),
        Title = data[3],
        ISBN = data[4],
        Publisher = data[5],
        PublishYear = int.Parse(data[6]),
        Price = int.Parse(data[7]),
        Theme = data[8],
        PageNumber = int.Parse(data[9]),
        Honorarium = int.Parse(data[10])
    });
}
    //Írjuk ki a képernyőre az össz adatot
    Console.WriteLine($"feladat 1: ");
    foreach(var book in books)
    {
        Console.WriteLine(book.ToString());
    }

    //Keressük ki az informatika témájú könyveket és mentsük el őket az informatika.txt állományba
    var ITBooks = fileData.Where(x => x.Contains("informatika"));
    await File.WriteAllLinesAsync("informatika.txt", ITBooks, Encoding.UTF8);

    //1900.txt állományba mentsük el azokat a könyveket, amelyek az 1900-as években írodtak
    var booksPublishedIn20thCentury = books.Where(x => x.PublishYear >= 1900 && x.PublishYear < 2000)
                                           .Select(x => x.ToFullString());
    await File.WriteAllLinesAsync("1900.txt", booksPublishedIn20thCentury, Encoding.UTF8);

    //Rendezzük az adatokat a könyvek oldalainak száma szerint csökkenő sorrendbe és a sorbarakott.txt állományba mentsük el.
    Console.WriteLine(""); 


Console.ReadKey();