using Microsoft.AspNetCore.Mvc;
using real_state_web_api.Models.Entities;

namespace real_state_web_api.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public abstract class StandardController<T> : ControllerBase
    where T : EntityModel, new()
{
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPost]
    [Route("")]
    public async Task<ActionResult> Create([FromBody] T model)
    {
        var result = model;

        await Task.CompletedTask;

        return Created($"/{result.Id}", result);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Retrieve()
    {
        await Task.CompletedTask;
        return Ok(new List<T> { new T(), new T(), new T() });
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> RetrieveById([FromRoute] string id)
    {
        await Task.CompletedTask;
        return Ok(new T { Id = id });
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPut]
    [Route("")]
    public async Task<ActionResult> Update([FromBody] T model)
    {
        var result = model;

        await Task.CompletedTask;

        return Ok(result);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete([FromRoute] string id)
    {
        await Task.CompletedTask;
        return NoContent();
    }
}
