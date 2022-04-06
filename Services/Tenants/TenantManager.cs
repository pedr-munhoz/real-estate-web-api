
using real_estate_web_api.Models.Entities.Tenants;

namespace real_estate_web_api.Services.Tenants;

public class TenantManager : ITenantManager
{
    private readonly IRepository<Tenant> _repository;

    public TenantManager(IRepository<Tenant> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<Tenant>> Create(Tenant entity)
    {
        var taxDocumentAvailableResult = await CheckTaxDocument(entity.Person.TaxDocument);

        if (!taxDocumentAvailableResult.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailableResult.Error);
            return new ServiceResult<Tenant>(taxDocumentAvailableResult.Error);
        }

        var result = await _repository.Create(entity);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult> Delete(long id)
    {
        var result = await _repository.Delete(id);

        return result;
    }

    public async Task<ServiceResult<List<Tenant>>> Retrieve()
    {
        var result = await _repository.Retrieve();

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<Tenant>> Retrieve(long id)
    {
        var result = await _repository.Find(x => x.Id == id);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<List<Tenant>>> Search(Func<Tenant, bool> filter)
    {
        var result = await _repository.Search(filter);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<Tenant>> Update(Tenant entity)
    {
        var existingPersonResult = await _repository.Find(x => x.Person.TaxDocument == entity.Person.TaxDocument);

        if (!existingPersonResult.Success)
            return ToEntityResult(existingPersonResult);

        if (existingPersonResult.Content == null)
            return ToEntityResult(new ServiceResult<Tenant>(new ServiceError("Error", "Internal server Error", 500)));

        var taxDocumentAvailable = await CheckTaxDocument(entity.Person.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<Tenant>(taxDocumentAvailable.Error);
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

    private ServiceResult<Tenant> ToEntityResult(ServiceResult<Tenant> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<Tenant>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<Tenant>(result.Error);
    }

    private ServiceResult<List<Tenant>> ToEntityResult(ServiceResult<List<Tenant>> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<List<Tenant>>(new List<Tenant>(result.Content));
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<List<Tenant>>(result.Error);
    }
}
