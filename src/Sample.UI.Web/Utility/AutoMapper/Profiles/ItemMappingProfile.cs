using Sample.Domain.Model.Item.Entity.Gold;
using Sample.Domain.Shared.Item;

namespace Sample.UI.Web.Utility.AutoMapper.Profiles
{
    public class ItemMappingProfile : MappingProfileBase
    {
        public ItemMappingProfile()
        {
            CreateMap<ItemGold, ItemGoldDto>();
        }
    }
}
