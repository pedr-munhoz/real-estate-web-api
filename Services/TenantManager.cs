using real_estate_web_api.Models.Entities.People;

namespace real_estate_web_api.Services;

public class TenantManager : StandardManager<ITenant>
{
    public TenantManager(IRepository<ITenant> repository) : base(repository)
    {
    }

    public async override Task<ServiceResult<ITenant>> Create(ITenant entity)
    {
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<ITenant>(taxDocumentAvailable.Error);
        }

        var result = await _repository.Create(entity);

        return result;
    }

    public async override Task<ServiceResult<ITenant>> Update(ITenant entity)
    {
        var taxDocumentAvailable = await CheckTaxDocument(entity.TaxDocument);

        if (!taxDocumentAvailable.Success)
        {
            ArgumentNullException.ThrowIfNull(taxDocumentAvailable.Error);
            return new ServiceResult<ITenant>(taxDocumentAvailable.Error);
        }

        var result = await _repository.Update(entity);

        return result;
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
}

