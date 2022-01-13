using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Services;

public class OwnerManager : StandardManager<IOwner>
{
    public OwnerManager(IRepository<IOwner> repository) : base(repository)
    {
    }

    public async override Task<ServiceResult<IOwner>> Create(IOwner entity)
    {
        var owners = await _repository.Search(x => x.TaxDocument == entity.TaxDocument);

        if (!owners.Success || owners.Content == null)
        {
            var serverError = new ServiceError(
                error: "Operation failed",
                message: "The operation couldnt be completed due to a unexpected error",
                code: 500);

            return new ServiceResult<IOwner>(serverError);
        }

        if (owners.Content.Any())
        {
            var duplicateTaxDocumentError = new ServiceError(
                error: "Duplicate tax document",
                message: $"Tax document '{entity.TaxDocument}' already registered",
                code: 422);

            return new ServiceResult<IOwner>(duplicateTaxDocumentError);
        }

        var result = await _repository.Create(entity);

        return result;
    }

    public async override Task<ServiceResult<IOwner>> Update(IOwner entity)
    {
        var result = await _repository.Update(entity);

        return result;
    }
}
