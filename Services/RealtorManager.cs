using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Services;

public class RealtorManager : IManager<IRealtor>
{
    private readonly IRepository<Person> _repository;

    public RealtorManager(IRepository<Person> repository)
    {
        _repository = repository;
    }

    public async Task<ServiceResult<IRealtor>> Create(IRealtor entity)
    {
        var taxDocumentAvailableResult = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailableResult.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailableResult.Error);
            return new ServiceResult<IRealtor>(taxDocumentAvailableResult.Error);
        }

        var existingPersonResult = await _repository.Find(x => x.TaxDocument == entity.TaxDocument && !x.IsRealtor);

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

    public async Task<ServiceResult<List<IRealtor>>> Retrieve()
    {
        var result = await _repository.Search(x => x.IsRealtor);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<IRealtor>> Retrieve(string id)
    {
        var result = await _repository.Find(x => x.IsRealtor && x.Id == id);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<List<IRealtor>>> Search(Func<IRealtor, bool> filter)
    {
        var result = await _repository.Search(filter, x => x.IsRealtor);

        return ToEntityResult(result);
    }

    public async Task<ServiceResult<IRealtor>> Update(IRealtor entity)
    {
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<IRealtor>(taxDocumentAvailable.Error);
        }

        var existingPersonResult = await _repository.Find(x => x.TaxDocument == entity.TaxDocument && !x.IsRealtor);

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
        var entities = await _repository.Search(x => x.TaxDocument == taxDocument && x.IsRealtor);

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

    private Person ToPerson(IRealtor entity)
    {
        return new Person
        {
            IsRealtor = true,
            Id = entity.Id,
            TaxDocument = entity.TaxDocument,
            Address = entity.Address,
            BirthDate = entity.BirthDate,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Mobile = entity.Mobile,
        };
    }

    private void CopyToPerson(IRealtor entity, Person person)
    {
        person.IsRealtor = true;
        person.Id = entity.Id;
        person.TaxDocument = entity.TaxDocument;
        person.Address = entity.Address;
        person.BirthDate = entity.BirthDate;
        person.FirstName = entity.FirstName;
        person.LastName = entity.LastName;
        person.Mobile = entity.Mobile;
    }

    private ServiceResult<IRealtor> ToEntityResult(ServiceResult<Person> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<IRealtor>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<IRealtor>(result.Error);
    }

    private ServiceResult<List<IRealtor>> ToEntityResult(ServiceResult<List<Person>> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<List<IRealtor>>(new List<IRealtor>(result.Content));
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<List<IRealtor>>(result.Error);
    }
}