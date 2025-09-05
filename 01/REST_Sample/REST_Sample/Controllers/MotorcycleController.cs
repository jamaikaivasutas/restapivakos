namespace REST_Sample.Controllers;

public class MotorcycleController : ControllerBase
{
    public List<string> Motorcycles = [
        "Honda GoldWing",
        "Honda Grom",
        "Piaggio Typhoon",
        "Suzuki GSXR600"
        ];

    [HttpGet]
    [Route("motorcycle/id/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required]int id)
    {
        return Ok(Motorcycles[id]);
    }

    [HttpGet]
    [Route("motorcycle")]
    public async Task<IActionResult> GetByQueryAsync([FromQuery][Required] int id)
    {
        return Ok(Motorcycles[id]);
    }

    [HttpGet]
    [Route("motorcycle/all")]
    public async Task<IActionResult> GetAllAsync() 
    {
        return Ok(Motorcycles);
    }

    [HttpPost]
    [Route("motorcycle/create")]
    public async Task<IActionResult> CreateAsync([FromBody] [Required] string motorcycle)
    {
        Motorcycles.Add(motorcycle);

        return Ok(Motorcycles);
    }

    [HttpPut]
    [Route("motorcycle/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] MotorcycleUpdateModel model)
    {
        Motorcycles[model.Id] = model.Name;

        return Ok(Motorcycles);
    }

    [HttpDelete]
    [Route("motorcycle/id/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        Motorcycles.RemoveAt(id);

        return Ok(Motorcycles);
    }
}