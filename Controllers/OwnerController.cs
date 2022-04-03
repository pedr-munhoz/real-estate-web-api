using Microsoft.AspNetCore.Mvc;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Results;
using real_estate_web_api.Models.ViewModels;
using real_estate_web_api.Services.Owners;

namespace real_estate_web_api.Controllers;

public class OwnerController : StandardController<IOwner, OwnerViewModel, OwnerResult>
{
    public OwnerController(IOwnerManager manager) : base(manager)
    {
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpGet]
    [Route("search")]
    public async Task<ActionResult> Search([FromQuery] string? taxDocument, string? lastName)
    {
        var result = await _manager.Search(x =>
            (x.Person.TaxDocument == taxDocument || taxDocument == null) &&
            (x.Person.LastName == lastName || lastName == null)
        );

        if (result.Success && result.Content != null)
            return Ok(result.Content.Select(x => new OwnerResult(x)).ToList());

        return UnprocessableEntity(result.Error);
    }
}
