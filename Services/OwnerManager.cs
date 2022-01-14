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
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<IOwner>(taxDocumentAvailable.Error);
        }

        var existingPerson = await _repository.Find(x => x.TaxDocument == entity.TaxDocument && !x.IsOwner);

        if (existingPerson.Success && existingPerson.Content != null)
        {
            var updatedPerson = existingPerson.Content;
            CopyToPerson(entity, updatedPerson);

            var updateResult = await _repository.Update(updatedPerson);
            return ToOwnerResult(updateResult);
        }

        var result = await _repository.Create(ToPerson(entity));

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult> Delete(string id)
    {
        var result = await _repository.Delete(id);

        return result;
    }

    public async Task<ServiceResult<List<IOwner>>> Retrieve()
    {
        var result = await _repository.Search(x => x.IsOwner);

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult<IOwner>> Retrieve(string id)
    {
        var result = await _repository.Find(x => x.IsOwner && x.Id == id);

        return ToOwnerResult(result);
    }

    // TODO: filter owners
    public async Task<ServiceResult<List<IOwner>>> Search(Func<IOwner, bool> expression)
    {
        var result = await _repository.Search(expression);

        return ToOwnerResult(result);
    }

    // TODO: filter owners
    public async Task<ServiceResult<IOwner>> Update(IOwner entity)
    {
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<IOwner>(taxDocumentAvailable.Error);
        }

        var result = await _repository.Update(ToPerson(entity));

        return ToOwnerResult(result);
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

    private Person ToPerson(IOwner owner)
    {
        return new Person
        {
            IsOwner = true,
            Id = owner.Id,
            TaxDocument = owner.TaxDocument,
            Address = owner.Address,
            BirthDate = owner.BirthDate,
            FirstName = owner.FirstName,
            LastName = owner.LastName,
            Mobile = owner.Mobile,
        };
    }

    private void CopyToPerson(IOwner owner, Person person)
    {
        person.IsOwner = true;
        person.Id = owner.Id;
        person.TaxDocument = owner.TaxDocument;
        person.Address = owner.Address;
        person.BirthDate = owner.BirthDate;
        person.FirstName = owner.FirstName;
        person.LastName = owner.LastName;
        person.Mobile = owner.Mobile;
    }

    private ServiceResult<IOwner> ToOwnerResult(ServiceResult<Person> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<IOwner>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<IOwner>(result.Error);
    }

    private ServiceResult<List<IOwner>> ToOwnerResult(ServiceResult<List<Person>> result)
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
