using Newtonsoft.Json;
using real_estate_web_api.Models.Entities.Owners;
using real_estate_web_api.Models.Entities.People;
using real_estate_web_api.Models.Entities.RealEstates;
using real_estate_web_api.Models.Entities.Realtors;
using real_estate_web_api.Models.Enumerations;

namespace real_estate_web_api.Models.Results
{
    public class RealEstateResult : Result<IRealEstate>, IRealEstate
    {
        public RealEstateResult()
        {
        }

        public RealEstateResult(IRealEstate entity) : base(entity)
        {
            Address = entity.Address;
            Type = entity.Type;
            GrossBuildingArea = entity.GrossBuildingArea;
            Bedrooms = entity.Bedrooms;
            ParkingSpaces = entity.ParkingSpaces;
            SaleAvailable = entity.SaleAvailable;
            SaleAmount = entity.SaleAmount;
            RentAvailable = entity.RentAvailable;
            RentAmount = entity.RentAmount;
            OwnerId = entity.Owner?.Id;
            RealtorId = entity.Realtor?.Id;
        }

        public string Address { get; set; } = "";
        public BuildingType Type { get; set; }
        public int GrossBuildingArea { get; set; }
        public int Bedrooms { get; set; }
        public int ParkingSpaces { get; set; }
        public bool SaleAvailable { get; set; }
        public double? SaleAmount { get; set; }
        public bool RentAvailable { get; set; }
        public double? RentAmount { get; set; }

        [JsonIgnore]
        public Owner Owner { get; set; } = new Owner();
        public long? OwnerId { get; set; }

        [JsonIgnore]
        public Realtor Realtor { get; set; } = new Realtor();
        public long? RealtorId { get; set; }

        public override Result<IRealEstate> Instantiate(IRealEstate entity)
            => new RealEstateResult(entity);
    }
}