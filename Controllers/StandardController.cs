using Microsoft.AspNetCore.Mvc;
using real_estate_web_api.Models.Entities;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services;

namespace real_estate_web_api.Controllers;

[ApiController]
[Route("api/v2/[controller]")]
public abstract class StandardController<TEntity, TModel, TResult> : ControllerBase
    where TEntity : IEntityModel
    where TModel : ViewModel<TEntity>, new()
    where TResult : Result<TEntity>, new()
{
    private readonly IRepository<TEntity> _repository;

    protected StandardController(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ServiceError), StatusCodes.Status422UnprocessableEntity)]
    [HttpPost]
    [Route("")]
    public async Task<ActionResult> Create([FromBody] TModel model)
    {
        var result = await _repository.Create(model.Map());

        if (result.Success && result.Content != null)
            return Created($"/{result.Content.Id}", new TResult().Instantiate(result.Content));

        return UnprocessableEntity(result.Error);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    [Route("")]
    public async Task<ActionResult> Retrieve()
    {
        var result = await _repository.Retrieve();

        if (result.Success && result.Content != null)
            return Ok(result.Content.Select(x => new TResult().Instantiate(x)).ToList());

        return UnprocessableEntity(result.Error);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceError), StatusCodes.Status404NotFound)]
    [HttpGet]
    [Route("{id}")]
    public async Task<ActionResult> RetrieveById([FromRoute] long id)
    {
        var result = await _repository.Retrieve(id);

        if (result.Success && result.Content != null)
            return Ok(new TResult().Instantiate(result.Content));

        return NotFound(result.Error);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ServiceError), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ServiceError), StatusCodes.Status422UnprocessableEntity)]
    [HttpPut]
    [Route("")]
    public async Task<ActionResult> Update([FromBody] TModel model)
    {
        var result = await _repository.Update(model.Map());

        if (result.Success && result.Content != null)
            return Ok(new TResult().Instantiate(result.Content));
        else if (result.Error != null && result.Error.Code == 404)
            return NotFound(result.Error);

        return UnprocessableEntity(result.Error);
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ServiceError), StatusCodes.Status404NotFound)]
    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult> Delete([FromRoute] long id)
    {
        var result = await _repository.Delete(id);

        if (result.Success)
            return NoContent();

        return NotFound(result.Error);
    }
}
