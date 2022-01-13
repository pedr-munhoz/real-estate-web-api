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
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<IRealtor>(taxDocumentAvailable.Error);
        }

        var result = await _repository.Create(ToPerson(entity));

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult> Delete(string id)
    {
        var result = await _repository.Delete(id);

        return result;
    }

    public async Task<ServiceResult<List<IRealtor>>> Retrieve()
    {
        var result = await _repository.Retrieve();

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult<IRealtor>> Retrieve(string id)
    {
        var result = await _repository.Retrieve(id);

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult<List<IRealtor>>> Search(Func<IRealtor, bool> expression)
    {
        var result = await _repository.Search(expression);

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult<IRealtor>> Update(IRealtor entity)
    {
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<IRealtor>(taxDocumentAvailable.Error);
        }

        var result = await _repository.Update(ToPerson(entity));

        return ToOwnerResult(result);
    }

    private async Task<ServiceResult> CheckTaxDocument(string taxDocument)
    {
        var owners = await _repository.Search(x => x.TaxDocument == taxDocument);

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

    private Person ToPerson(IRealtor owner)
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

    private ServiceResult<IRealtor> ToOwnerResult(ServiceResult<Person> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<IRealtor>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<IRealtor>(result.Error);
    }

    private ServiceResult<List<IRealtor>> ToOwnerResult(ServiceResult<List<Person>> result)
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
