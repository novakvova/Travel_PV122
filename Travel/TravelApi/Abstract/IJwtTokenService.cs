using TravelApi.Data.Entity.Identity;

namespace TravelApi.Abstract
{
    public interface IJwtTokenService
    {

        Task<string> CreateToken(UserEntity user);
        void DeleteToken(UserEntity user);

    }
}

