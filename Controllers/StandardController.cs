using Microsoft.AspNetCore.Mvc;
using real_state_web_api.Models;

namespace real_state_web_api.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public abstract class StandardController<T> : ControllerBase
    where T : EntityModel, new()
{
    [HttpPost]
    [Route("")]
    public async Task<ActionResult> Create([FromBody] T model)
    {
        var result = model;

        await Task.CompletedTask;

        return Created($"/{result.Id}", result);
    }

    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Retrieve()
    {
        await Task.CompletedTask;
        return Ok(new List<T>());
    }

    [HttpGet]
    [Route("{id:string}")]
    public async Task<ActionResult> RetrieveById([FromRoute] string id)
    {
        await Task.CompletedTask;
        return Ok(new T { Id = id });
    }

    [HttpPut]
    [Route("")]
    public async Task<ActionResult> Update([FromBody] T model)
    {
        var result = model;

        await Task.CompletedTask;

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id:string}")]
    public async Task<ActionResult> Delete([FromRoute] string id)
    {
        await Task.CompletedTask;
        return Ok(new T { Id = id });
    }
}
