using Microsoft.AspNetCore.Mvc;
using real_estate_web_api.Models.Entities;
using real_estate_web_api.Models.ViewModels;

namespace real_estate_web_api.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public abstract class StandardController<IEntity, TModel> : ControllerBase
    where IEntity : IEntityModel
    where TModel : ViewModel<IEntity>, new()
{
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPost]
    [Route("")]
    public async Task<ActionResult> Create([FromBody] TModel model)
    {
        var result = model.Map();

        await Task.CompletedTask;

        return Created($"/{result.Id}", result);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Retrieve()
    {
        await Task.CompletedTask;
        return Ok(new List<IEntity> { new TModel().Map(), new TModel().Map(), new TModel().Map() });
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> RetrieveById([FromRoute] string id)
    {
        await Task.CompletedTask;
        return Ok(new TModel { Id = id }.Map());
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
    [HttpPut]
    [Route("")]
    public async Task<ActionResult> Update([FromBody] TModel model)
    {
        var result = model.Map();

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
