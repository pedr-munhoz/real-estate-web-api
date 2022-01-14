using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Services;

public class TenantManager : IManager<ITenant>
{
    private readonly IRepository<Person> _repository;

    public TenantManager(IRepository<Person> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<ITenant>> Create(ITenant entity)
    {
        var taxDocumentAvailableResult = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailableResult.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailableResult.Error);
            return new ServiceResult<ITenant>(taxDocumentAvailableResult.Error);
        }

        var existingPersonResult = await _repository.Find(x => x.TaxDocument == entity.TaxDocument && !x.IsTenant);

        if (existingPersonResult.Success && existingPersonResult.Content != null)
        {
            var updatedPerson = existingPersonResult.Content;
            CopyToPerson(entity, updatedPerson);

            var updateResult = await _repository.Update(updatedPerson);
            return ToEntityResult(updateResult);
        }

        var result = await _repository.Create(ToPerson(entity));

        return ToEntityResult(result);
    }

    public async Task<ServiceResult> Delete(string id)
    {
        var result = await _repository.Delete(id);

        return result;
    }

    public async Task<ServiceResult<List<ITenant>>> Retrieve()
    {
        var result = await _repository.Search(x => x.IsTenant);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<ITenant>> Retrieve(string id)
    {
        var result = await _repository.Find(x => x.IsTenant && x.Id == id);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<List<ITenant>>> Search(Func<ITenant, bool> filter)
    {
        var result = await _repository.Search(filter, x => x.IsTenant);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<ITenant>> Update(ITenant entity)
    {
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<ITenant>(taxDocumentAvailable.Error);
        }

        var existingPersonResult = await _repository.Find(x => x.TaxDocument == entity.TaxDocument && !x.IsTenant);

        if (existingPersonResult.Success && existingPersonResult.Content != null)
        {
            var updatedPerson = existingPersonResult.Content;
            CopyToPerson(entity, updatedPerson);

            var updateResult = await _repository.Update(updatedPerson);
            return ToEntityResult(updateResult);
        }

        return ToEntityResult(existingPersonResult);
    }

    private async Task<ServiceResult> CheckTaxDocument(string taxDocument)
    {
        var entities = await _repository.Search(x => x.TaxDocument == taxDocument && x.IsTenant);

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

    private Person ToPerson(ITenant entity)
    {
        return new Person
        {
            IsTenant = true,
            Id = entity.Id,
            TaxDocument = entity.TaxDocument,
            Address = entity.Address,
            BirthDate = entity.BirthDate,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Mobile = entity.Mobile,
            Income = entity.Income,
            InterestedInBuying = entity.InterestedInBuying,
        };
    }

    private void CopyToPerson(ITenant entity, Person person)
    {
        person.IsTenant = true;
        person.Id = entity.Id;
        person.TaxDocument = entity.TaxDocument;
        person.Address = entity.Address;
        person.BirthDate = entity.BirthDate;
        person.FirstName = entity.FirstName;
        person.LastName = entity.LastName;
        person.Mobile = entity.Mobile;
        person.Income = entity.Income;
        person.InterestedInBuying = entity.InterestedInBuying;
    }

    private ServiceResult<ITenant> ToEntityResult(ServiceResult<Person> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<ITenant>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<ITenant>(result.Error);
    }

    private ServiceResult<List<ITenant>> ToEntityResult(ServiceResult<List<Person>> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<List<ITenant>>(new List<ITenant>(result.Content));
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<List<ITenant>>(result.Error);
    }
}
