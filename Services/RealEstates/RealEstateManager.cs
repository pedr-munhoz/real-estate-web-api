using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Services.Owners;
using real_estate_web_api.Services.Realtors;

namespace real_estate_web_api.Services.RealEstates;

public class RealEstateManager : StandardManager<RealEstate>, IRealEstateManager
{
    private readonly IOwnerManager _ownerManager;
    private readonly IRealtorManager _realtorManager;
    public RealEstateManager(IRepository<RealEstate> repository, IOwnerManager ownerManager, IRealtorManager realtorManager)
        : base(repository)
    {
        _ownerManager = ownerManager;
        _realtorManager = realtorManager;
    }

    public override async Task<ServiceResult<RealEstate>> Create(RealEstate entity)
    {
        var validReferencesResult = await CheckReferences(entity);
        if (!validReferencesResult.Success)
            return validReferencesResult;

        return await base.Create(entity);
    }

    public override async Task<ServiceResult<RealEstate>> Update(RealEstate entity)
    {
        var validOwnerResult = await CheckOwner(entity);
        if (!validOwnerResult.Success)
            return validOwnerResult;

        return await base.Update(entity);
    }

    private async Task<ServiceResult<RealEstate>> CheckReferences(RealEstate entity)
    {
        var validOwnerResult = await CheckOwner(entity);
        if (!validOwnerResult.Success)
            return validOwnerResult;

        var validRealtorResult = await CheckRealtor(entity);
        if (!validRealtorResult.Success)
            return validRealtorResult;

        return new ServiceResult<RealEstate>(new RealEstate());
    }

    private async Task<ServiceResult<RealEstate>> CheckOwner(RealEstate entity)
    {
        var exists = await _ownerManager.Retrieve(entity.Owner.Id);

        if (exists.Success && exists.Content != null)
        {
            entity.Owner = exists.Content;
            return new ServiceResult<RealEstate>(new RealEstate());
        }

        var error = new ServiceError(
            "Owner not found",
            $"No Owner could be located with id: {entity.Owner.Id}",
            404);

        return new ServiceResult<RealEstate>(error);
    }

    private async Task<ServiceResult<RealEstate>> CheckRealtor(RealEstate entity)
    {
        var exists = await _realtorManager.Retrieve(entity.Realtor.Id);

        if (exists.Success && exists.Content != null)
        {
            entity.Realtor = exists.Content;
            return new ServiceResult<RealEstate>(new RealEstate());
        }

        var error = new ServiceError(
            "Realtor not found",
            $"No Realtor could be located with id: {entity.Realtor.Id}",
            404);

        return new ServiceResult<RealEstate>(error);
    }
}
