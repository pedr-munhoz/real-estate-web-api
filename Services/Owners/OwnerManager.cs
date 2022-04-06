using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Services.Owners;

public class OwnerManager : IOwnerManager
{
    private readonly IRepository<Owner> _repository;

    public OwnerManager(IRepository<Owner> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<Owner>> Create(Owner entity)
    {
        var taxDocumentAvailableResult = await CheckTaxDocument(entity.Person.TaxDocument);

        if (!taxDocumentAvailableResult.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailableResult.Error);
            return new ServiceResult<Owner>(taxDocumentAvailableResult.Error);
        }

        var result = await _repository.Create(entity);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult> Delete(long id)
    {
        var result = await _repository.Delete(id);

        return result;
    }

    public async Task<ServiceResult<List<Owner>>> Retrieve()
    {
        var result = await _repository.Retrieve();

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<Owner>> Retrieve(long id)
    {
        var result = await _repository.Find(x => x.Id == id);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<List<Owner>>> Search(Func<Owner, bool> filter)
    {
        var result = await _repository.Search(filter);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<Owner>> Update(Owner entity)
    {
        var existingPersonResult = await _repository.Find(x => x.Person.TaxDocument == entity.Person.TaxDocument);

        if (!existingPersonResult.Success)
            return ToEntityResult(existingPersonResult);

        if (existingPersonResult.Content == null)
            return ToEntityResult(new ServiceResult<Owner>(new ServiceError("Error", "Internal server Error", 500)));

        var taxDocumentAvailable = await CheckTaxDocument(entity.Person.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<Owner>(taxDocumentAvailable.Error);
        }

        var updateResult = await _repository.Update(entity);
        return ToEntityResult(updateResult);
    }

    private async Task<ServiceResult> CheckTaxDocument(string taxDocument)
    {
        var entities = await _repository.Search(x => x.Person.TaxDocument == taxDocument);

        if (!entities.Success || entities.Content == null)
        {
            var serverError = new ServiceError(
                error: "Operation failed",
                message: "The operation couldnt be completed due to a unexpected error",
                code: 500);

            return new ServiceResult(success: false, serverError);
        }

        if (entities.Content.Any())
        {
            var duplicateTaxDocumentError = new ServiceError(
                error: "Duplicate tax document",
                message: $"Tax document '{taxDocument}' already registered",
                code: 422);

            return new ServiceResult(success: false, duplicateTaxDocumentError);
        }

        return new ServiceResult(success: true);
    }

    private ServiceResult<Owner> ToEntityResult(ServiceResult<Owner> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<Owner>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<Owner>(result.Error);
    }

    private ServiceResult<List<Owner>> ToEntityResult(ServiceResult<List<Owner>> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<List<Owner>>(new List<Owner>(result.Content));
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<List<Owner>>(result.Error);
    }
}
