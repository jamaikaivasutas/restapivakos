namespace Roplabda;

public class Volleyball
{
    public string Name { get; set; }
    public int Height { get; set; }
    public string Post { get; set; }
    public string Nationality { get; set; }
    public string Team { get; set; }
    public string Country { get; set; }

    public string ToFullString()
    {
        return $"{Name}\t{Height}\t{Post}\t{Nationality}\t{Team}\t{Country}";
    }
}
