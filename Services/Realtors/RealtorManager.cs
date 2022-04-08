using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.Realtors;

namespace real_estate_web_api.Services.Realtors;

public class RealtorManager : IRealtorManager
{
    private readonly IRepository<Realtor> _repository;

    public RealtorManager(IRepository<Realtor> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<Realtor>> Create(Realtor entity)
    {
        var taxDocumentAvailableResult = await CheckTaxDocument(entity.Person.TaxDocument);

        if (!taxDocumentAvailableResult.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailableResult.Error);
            return new ServiceResult<Realtor>(taxDocumentAvailableResult.Error);
        }

        var result = await _repository.Create(entity);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult> Delete(long id)
    {
        var result = await _repository.Delete(id);

        return result;
    }

    public async Task<ServiceResult<List<Realtor>>> Retrieve()
    {
        var result = await _repository.Retrieve();

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<Realtor>> Retrieve(long id)
    {
        var result = await _repository.Find(x => x.Id == id);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<List<Realtor>>> Search(Func<Realtor, bool> filter)
    {
        var result = await _repository.Search(filter);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<Realtor>> Update(Realtor entity)
    {
        var existingPersonResult = await _repository.Find(x => x.Person.TaxDocument == entity.Person.TaxDocument);

        if (!existingPersonResult.Success)
            return ToEntityResult(existingPersonResult);

        if (existingPersonResult.Content == null)
            return ToEntityResult(new ServiceResult<Realtor>(new ServiceError("Error", "Internal server Error", 500)));

        var taxDocumentAvailable = await CheckTaxDocument(entity.Person.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<Realtor>(taxDocumentAvailable.Error);
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

    private ServiceResult<Realtor> ToEntityResult(ServiceResult<Realtor> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<Realtor>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<Realtor>(result.Error);
    }

    private ServiceResult<List<Realtor>> ToEntityResult(ServiceResult<List<Realtor>> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<List<Realtor>>(new List<Realtor>(result.Content));
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<List<Realtor>>(result.Error);
    }
}