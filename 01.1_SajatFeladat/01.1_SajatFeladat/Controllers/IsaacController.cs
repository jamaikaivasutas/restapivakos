
namespace _01._1_SajatFeladat.Controllers;

public class IsaacController : ControllerBase
{
    public List<string> Characters = [
        "Isaac",
        "Magdalene",
        "Cain",
        "Judas",
        "???",
        "Eve",
        "Samson",
        "Azazel",
        "Lazarus",
        "Eden",
        "The Lost",
        "Lilith",
        "Keeper",
        "Apollyon",
        "The Forgotten",
        "Bethany",
        "Jacob and Esau"
        ];

    [HttpGet]
    [Route("character/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        return Ok(Characters[id]);
    }

    [HttpGet]
    [Route("character")]
    public async Task<IActionResult> GetByQueryAsync([FromQuery][Required] int id)
    {
        return Ok(Characters[id]);
    }

    [HttpGet]
    [Route("character/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(Characters);
    }

    [HttpPost]
    [Route("character/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] string character)
    {
        Characters.Add(character);

        return Ok(Characters);
    }

    [HttpPut]
    [Route("character/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] CharacterUpdateModel model)
    {
        Characters[model.Id] = model.Name;

        return Ok(Characters);
    }

    [HttpDelete]
    [Route("character/id/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        Characters.RemoveAt(id);

        return Ok(Characters);
    }
}
