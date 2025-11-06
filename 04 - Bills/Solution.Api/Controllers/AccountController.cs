using Solution.Core.Interfaces;
using Solution.Core.Models;
using System.ComponentModel.DataAnnotations;

namespace Solution.Api.Controllers;

public class AccountController(IAccountService accountService) : BaseController
{
    [HttpGet]
    [Route("api/account/all")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await accountService.GetAllAsync();
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/account/page/{page}")]
    public async Task<IActionResult> GetPageAsync([FromRoute][Required] int page = 0)
    {
        var result = await accountService.GetPageAsync(page);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    [Route("api/account/{id}")]
    public async Task<IActionResult> GetByIdAsync([FromRoute][Required] int id)
    {
        var result = await accountService.GetByIdAsync(id);
        return result.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpPost]
    [Route("api/account/create")]
    public async Task<IActionResult> CreateAsync([FromBody][Required] AccountModel model)
    {
        var result = await accountService.CreateAsync(model);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpPut]
    [Route("api/account/update")]
    public async Task<IActionResult> UpdateAsync([FromBody][Required] AccountModel model)
    {
        var result = await accountService.UpdateAsync(model);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }

    [HttpDelete]
    [Route("api/account/delete/{id}")]
    public async Task<IActionResult> DeleteAsync([FromRoute][Required] int id)
    {
        var result = await accountService.DeleteAsync(id);
        return result.Match(
            result => Ok(new OkResult()),
            errors => Problem(errors)
        );
    }
}
