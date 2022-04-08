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
        var validRealEstateResult = await CheckRealEstate(entity);
        if (!validRealEstateResult.Success)
            return validRealEstateResult;

        var validRealtorResult = await CheckRealtor(entity);
        if (!validRealtorResult.Success)
            return validRealtorResult;

        var validTenantResult = await CheckTenant(entity);
        if (!validTenantResult.Success)
            return validTenantResult;

        return new ServiceResult<Rental>(new Rental());
    }

    private async Task<ServiceResult<Rental>> CheckRealEstate(Rental entity)
    {
        var exists = await _realEstateManager.Retrieve(entity.RealEstate.Id);

        if (exists.Success && exists.Content != null)
        {
            entity.RealEstate = exists.Content;
            return new ServiceResult<Rental>(new Rental());
        }

        var error = new ServiceError(
            "RealEstate not found",
            $"No RealEstate could be located with id: {entity.RealEstate.Id}",
            404);

        return new ServiceResult<Rental>(error);
    }

    private async Task<ServiceResult<Rental>> CheckRealtor(Rental entity)
    {
        var exists = await _realtorManager.Retrieve(entity.Realtor.Id);

        if (exists.Success && exists.Content != null)
        {
            entity.Realtor = exists.Content;
            return new ServiceResult<Rental>(new Rental());
        }

        var error = new ServiceError(
            "Realtor not found",
            $"No Realtor could be located with id: {entity.Realtor.Id}",
            404);

        return new ServiceResult<Rental>(error);
    }

    private async Task<ServiceResult<Rental>> CheckTenant(Rental entity)
    {
        var exists = await _tenantManager.Retrieve(entity.Tenant.Id);

        if (exists.Success && exists.Content != null)
        {
            entity.Tenant = exists.Content;
            return new ServiceResult<Rental>(new Rental());
        }

        var error = new ServiceError(
            "Tenant not found",
            $"No tenant could be located with id: {entity.Tenant.Id}",
            404);

        return new ServiceResult<Rental>(error);
    }
}
