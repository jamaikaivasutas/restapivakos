namespace NB1;

public class Player
{
    public int PlayerNumber { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public bool IsHungarianCitizen { get; set; }
    public bool IsForeignCitizen { get; set; }
    public int PayInThousand { get; set; }
    public string ClubName { get; set; }
    public string Post { get; set; }

    public string ToFullString()
    {
        return $"{FirstName}\t{LastName}\t{PlayerNumber}\t{DateOfBirth}\t{ClubName}\t{Post}";
    }
}
