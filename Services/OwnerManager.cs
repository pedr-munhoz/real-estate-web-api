using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Services;

public class OwnerManager : IManager<IOwner>
{
    private readonly IRepository<Person> _repository;

    public OwnerManager(IRepository<Person> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<IOwner>> Create(IOwner entity)
    {
        var taxDocumentAvailableResult = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailableResult.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailableResult.Error);
            return new ServiceResult<IOwner>(taxDocumentAvailableResult.Error);
        }

        var existingPersonResult = await _repository.Find(x => x.TaxDocument == entity.TaxDocument && !x.IsOwner);

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

    public async Task<ServiceResult<List<IOwner>>> Retrieve()
    {
        var result = await _repository.Search(x => x.IsOwner);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<IOwner>> Retrieve(string id)
    {
        var result = await _repository.Find(x => x.IsOwner && x.Id == id);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<List<IOwner>>> Search(Func<IOwner, bool> filter)
    {
        var result = await _repository.Search(filter, x => x.IsOwner);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<IOwner>> Update(IOwner entity)
    {
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<IOwner>(taxDocumentAvailable.Error);
        }

        var existingPersonResult = await _repository.Find(x => x.TaxDocument == entity.TaxDocument && !x.IsOwner);

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
        var owners = await _repository.Search(x => x.TaxDocument == taxDocument && x.IsOwner);

        if (!owners.Success || owners.Content == null)
        {
            var serverError = new ServiceError(
                error: "Operation failed",
                message: "The operation couldnt be completed due to a unexpected error",
                code: 500);

            return new ServiceResult(success: false, serverError);
        }

        if (owners.Content.Any())
        {
            var duplicateTaxDocumentError = new ServiceError(
                error: "Duplicate tax document",
                message: $"Tax document '{taxDocument}' already registered",
                code: 422);

            return new ServiceResult(success: false, duplicateTaxDocumentError);
        }

        return new ServiceResult(success: true);
    }

    private Person ToPerson(IOwner entity)
    {
        return new Person
        {
            IsOwner = true,
            Id = entity.Id,
            TaxDocument = entity.TaxDocument,
            Address = entity.Address,
            BirthDate = entity.BirthDate,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Mobile = entity.Mobile,
        };
    }

    private void CopyToPerson(IOwner entity, Person person)
    {
        person.IsOwner = true;
        person.Id = entity.Id;
        person.TaxDocument = entity.TaxDocument;
        person.Address = entity.Address;
        person.BirthDate = entity.BirthDate;
        person.FirstName = entity.FirstName;
        person.LastName = entity.LastName;
        person.Mobile = entity.Mobile;
    }

    private ServiceResult<IOwner> ToEntityResult(ServiceResult<Person> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<IOwner>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<IOwner>(result.Error);
    }

    private ServiceResult<List<IOwner>> ToEntityResult(ServiceResult<List<Person>> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<List<IOwner>>(new List<IOwner>(result.Content));
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<List<IOwner>>(result.Error);
    }
}
