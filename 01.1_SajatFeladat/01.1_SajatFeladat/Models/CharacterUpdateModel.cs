namespace _01._1_SajatFeladat.Models;

public class CharacterUpdateModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }
}
