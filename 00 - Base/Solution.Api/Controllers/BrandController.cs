

namespace Solution.Api.Controllers;

public class BrandController(IBrandService brandService) : BaseController
{
    [HttpGet]
    [Route("api/brand/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await brandService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
            );
    }

    [HttpGet]
    [Route("api/brand/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute][Required] int page = 0)
    {
        var result = await brandService.GetPagedAsync(page);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
            );
    }

    [HttpGet]
    [Route("api/brand/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await brandService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
            );
    }

    [HttpPost]
    [Route("api/brand/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] BrandModel model)
    {
        var result = await brandService.CreateAsync(model);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
            );
    }

    [HttpPut]
    [Route("api/brand/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] BrandModel model)
    {
        var result = await brandService.UpdateAsync(model);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
            );
    }

    [HttpDelete]
    [Route("api/brand/delete/{id}")]
    public async Task<IActionResult> DeleteByIdAsync([FromRoute][Required] int id)
    {
        var result = await brandService.DeleteAsync(id);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
            );
    }
}

