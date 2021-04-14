using BaseCore.Utilities.Results;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using Blog.Domain.Security.JWT;

namespace Blog.Domain.Interfaces
{
    public interface IAuthService
    {
        IDataResult<User> Register(RegisterDto registerDto, string password);
        IDataResult<User> ResetPassword(PasswordResetUserDto resetUserDto);
        IDataResult<User> Login(LoginDto loginDto);
        IDataResult<AccessToken> CreateAccessToken(Entities.User user);

    }
}
