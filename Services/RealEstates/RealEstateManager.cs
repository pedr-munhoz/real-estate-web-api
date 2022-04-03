using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Services.Owners;
using real_estate_web_api.Services.Realtors;

namespace real_estate_web_api.Services.RealEstates;

public class RealEstateManager : StandardManager<IRealEstate>, IRealEstateManager
{
    private readonly IOwnerManager _ownerManager;
    private readonly IRealtorManager _realtorManager;
    public RealEstateManager(IRepository<IRealEstate> repository, IOwnerManager ownerManager, IRealtorManager realtorManager)
        : base(repository)
    {
        _ownerManager = ownerManager;
        _realtorManager = realtorManager;
    }

    public override async Task<ServiceResult<IRealEstate>> Create(IRealEstate entity)
    {
        var validReferencesResult = await CheckReferences(entity);
        if (!validReferencesResult.Success)
            return validReferencesResult;

        return await base.Create(entity);
    }

    public override async Task<ServiceResult<IRealEstate>> Update(IRealEstate entity)
    {
        var validOwnerResult = await CheckOwner(entity.Owner.Id);
        if (!validOwnerResult.Success)
            return validOwnerResult;

        return await base.Update(entity);
    }

    private async Task<ServiceResult<IRealEstate>> CheckReferences(IRealEstate entity)
    {
        var validOwnerResult = await CheckOwner(entity.Owner.Id);
        if (!validOwnerResult.Success)
            return validOwnerResult;

        var validRealtorResult = await CheckRealtor(entity.Realtor.Id);
        if (!validRealtorResult.Success)
            return validRealtorResult;

        return new ServiceResult<IRealEstate>(new RealEstate());
    }

    private async Task<ServiceResult<IRealEstate>> CheckOwner(string id)
    {
        var exists = await _ownerManager.Retrieve(id);

        if (exists.Success && exists.Content != null)
        {
            return new ServiceResult<IRealEstate>(new RealEstate());
        }

        var error = new ServiceError(
            "Owner not found",
            $"No Owner could be located with id: {id}",
            404);

        return new ServiceResult<IRealEstate>(error);
    }

    private async Task<ServiceResult<IRealEstate>> CheckRealtor(string id)
    {
        var exists = await _realtorManager.Retrieve(id);

        if (exists.Success && exists.Content != null)
        {
            return new ServiceResult<IRealEstate>(new RealEstate());
        }

        var error = new ServiceError(
            "Realtor not found",
            $"No Realtor could be located with id: {id}",
            404);

        return new ServiceResult<IRealEstate>(error);
    }
}
