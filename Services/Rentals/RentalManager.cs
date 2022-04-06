using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Rentals;
using real_estate_web_api.Services.RealEstates;
using real_estate_web_api.Services.Realtors;
using real_estate_web_api.Services.Tenants;

namespace real_estate_web_api.Services.Rentals;

public class RentalManager : StandardManager<Rental>, IRentalManager
{
    private readonly IRealEstateManager _realEstateManager;
    private readonly IRealtorManager _realtorManager;
    private readonly ITenantManager _tenantManager;

    public RentalManager(
        IRepository<Rental> repository,
        IRealEstateManager realEstateManager,
        IRealtorManager realtorManager,
        ITenantManager tentantManager)
    : base(repository)
    {
        _realEstateManager = realEstateManager;
        _realtorManager = realtorManager;
        _tenantManager = tentantManager;
    }

    public override async Task<ServiceResult<Rental>> Create(Rental entity)
    {
        var validReferencesResult = await CheckReferences(entity);
        if (!validReferencesResult.Success)
            return validReferencesResult;

        return await base.Create(entity);
    }

    public override async Task<ServiceResult<Rental>> Update(Rental entity)
    {
        var validReferencesResult = await CheckReferences(entity);
        if (!validReferencesResult.Success)
            return validReferencesResult;

        return await base.Update(entity);
    }

    private async Task<ServiceResult<Rental>> CheckReferences(Rental entity)
    {
        var validRealEstateResult = await CheckRealEstate(entity.RealEstate.Id);
        if (!validRealEstateResult.Success)
            return validRealEstateResult;

        var validRealtorResult = await CheckRealtor(entity.Realtor.Id);
        if (!validRealtorResult.Success)
            return validRealtorResult;

        var validTenantResult = await CheckTenant(entity.Tenant.Id);
        if (!validTenantResult.Success)
            return validTenantResult;

        return new ServiceResult<Rental>(new Rental());
    }

    private async Task<ServiceResult<Rental>> CheckRealEstate(long id)
    {
        var exists = await _realEstateManager.Retrieve(id);

        if (exists.Success && exists.Content != null)
        {
            return new ServiceResult<Rental>(new Rental());
        }

        var error = new ServiceError(
            "RealEstate not found",
            $"No RealEstate could be located with id: {id}",
            404);

        return new ServiceResult<Rental>(error);
    }

    private async Task<ServiceResult<Rental>> CheckRealtor(long id)
    {
        var exists = await _realtorManager.Retrieve(id);

        if (exists.Success && exists.Content != null)
        {
            return new ServiceResult<Rental>(new Rental());
        }

        var error = new ServiceError(
            "Realtor not found",
            $"No Realtor could be located with id: {id}",
            404);

        return new ServiceResult<Rental>(error);
    }

    private async Task<ServiceResult<Rental>> CheckTenant(long id)
    {
        var exists = await _tenantManager.Retrieve(id);

        if (exists.Success && exists.Content != null)
        {
            return new ServiceResult<Rental>(new Rental());
        }

        var error = new ServiceError(
            "Tenant not found",
            $"No tenant could be located with id: {id}",
            404);

        return new ServiceResult<Rental>(error);
    }
}
