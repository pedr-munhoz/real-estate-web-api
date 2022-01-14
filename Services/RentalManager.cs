using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Rentals;

namespace real_estate_web_api.Services;

public class RentalManager : StandardManager<IRental>
{
    private readonly IManager<IRealEstate> _realEstateManager;
    private readonly IManager<IRealtor> _realtorManager;
    private readonly IManager<ITenant> _tenantManager;

    public RentalManager(
        IRepository<IRental> repository,
        IManager<IRealEstate> realEstateManager,
        IManager<IRealtor> realtorManager,
        IManager<ITenant> tentantManager)
    : base(repository)
    {
        _realEstateManager = realEstateManager;
        _realtorManager = realtorManager;
        _tenantManager = tentantManager;
    }

    public override async Task<ServiceResult<IRental>> Create(IRental entity)
    {
        var validRealEstateResult = await CheckRealEstate(entity);
        if (!validRealEstateResult.Success)
            return validRealEstateResult;

        var result = await _repository.Create(entity);

        return result;
    }

    public override async Task<ServiceResult<IRental>> Update(IRental entity)
    {
        var result = await _repository.Update(entity);

        return result;
    }

    private async Task<ServiceResult<IRental>> CheckRealEstate(IRental entity)
    {
        var exists = await _realEstateManager.Retrieve(entity.RealEstate.Id);

        if (exists.Success && exists.Content != null)
        {
            return new ServiceResult<IRental>(new Rental());
        }

        var error = new ServiceError(
                "RealEstate not found",
                $"No RealEstate could be located with id: {entity.RealEstate.Id}",
                404);

        return new ServiceResult<IRental>(error);
    }

    private async Task<ServiceResult> CheckRealtor(IRental entity)
    {
        var exists = await _realtorManager.Retrieve(entity.Realtor.Id);

        if (exists.Success && exists.Content != null)
        {
            return new ServiceResult(success: true);
        }

        return new ServiceResult(success: false, error: exists.Error);
    }

    private async Task<ServiceResult> CheckTenant(IRental entity)
    {
        var exists = await _tenantManager.Retrieve(entity.Tenant.Id);

        if (exists.Success && exists.Content != null)
        {
            return new ServiceResult(success: true);
        }

        return new ServiceResult(success: false, error: exists.Error);
    }
}
