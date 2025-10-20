namespace Solution.Api.Controllers;

public class ChocolateController(IChocolateService chocolateService) : BaseController
{
    [HttpGet]
    [Route("api/chocolate/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await chocolateService.GetAllAsync();
        return result .Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/chocolate/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute][Required] int page = 0)
    {
        var result = await chocolateService.GetPagedAsync(page);
        return result .Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/chocolate/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await chocolateService.GetByIdAsync(id);
        return result .Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/chocolate/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] ChocolateModel model)
    {
        var result = await chocolateService.CreateAsync(model);
        return result .Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/chocolate/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] ChocolateModel model)
    {
        var result = await chocolateService.UpdateAsync(model);
        return result .Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/chocolate/delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute][Required] int id)
    {
        var result = await chocolateService.DeleteAsync(id);
        return result .Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }
}