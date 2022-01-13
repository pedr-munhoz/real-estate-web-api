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
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<ITenant>(taxDocumentAvailable.Error);
        }

        var result = await _repository.Create(ToPerson(entity));

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult> Delete(string id)
    {
        var result = await _repository.Delete(id);

        return result;
    }

    public async Task<ServiceResult<List<ITenant>>> Retrieve()
    {
        var result = await _repository.Retrieve();

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult<ITenant>> Retrieve(string id)
    {
        var result = await _repository.Retrieve(id);

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult<List<ITenant>>> Search(Func<ITenant, bool> expression)
    {
        var result = await _repository.Search(expression);

        return ToOwnerResult(result);
    }

    public async Task<ServiceResult<ITenant>> Update(ITenant entity)
    {
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<ITenant>(taxDocumentAvailable.Error);
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

    private Person ToPerson(ITenant tenant)
    {
        return new Person
        {
            IsTenant = true,
            Id = tenant.Id,
            TaxDocument = tenant.TaxDocument,
            Address = tenant.Address,
            BirthDate = tenant.BirthDate,
            FirstName = tenant.FirstName,
            LastName = tenant.LastName,
            Mobile = tenant.Mobile,
            Income = tenant.Income,
            InterestedInBuying = tenant.InterestedInBuying,
        };
    }

    private ServiceResult<ITenant> ToOwnerResult(ServiceResult<Person> result)
    {
        if (result.Success)
        {
            ArgumentNullException.ThrowIfNull(result.Content);
            return new ServiceResult<ITenant>(result.Content);
        }

        ArgumentNullException.ThrowIfNull(result.Error);
        return new ServiceResult<ITenant>(result.Error);
    }

    private ServiceResult<List<ITenant>> ToOwnerResult(ServiceResult<List<Person>> result)
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
