using Microsoft.AspNetCore.Mvc;
using real_estate_web_api.Models.Entities;
using real_estate_web_api.Models.ViewModels;

namespace real_estate_web_api.Controllers;

public interface IController<TEntity, TModel>
    where TEntity : IEntityModel
    where TModel : ViewModel<TEntity>, new()
{
    Task<ActionResult> Create([FromBody] TModel model);
    Task<ActionResult> Delete([FromRoute] long id);
    Task<ActionResult> Retrieve();
    Task<ActionResult> RetrieveById([FromRoute] long id);
    Task<ActionResult> Update([FromBody] TModel model);
}
