using Sample.Domain.Model.User.Entity;
using Sample.Domain.Shared.User;

namespace Sample.UI.Web.Utility.AutoMapper.Profiles
{
    public class UserMappingProfile : MappingProfileBase
    {
        public UserMappingProfile()
        {
            CreateMap<UserBase, UserDto>();
        }
    }
}
