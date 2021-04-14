using BaseCore.Utilities.Results;
using Blog.Domain.DataTransferObjects;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Blog.Domain.Security.Hashing;
using Blog.Domain.Security.JWT;

namespace Blog.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserRoleService _userRoleService;
        private readonly IPasswordHasher _passwordHasher;
        public AuthService(
            IUserService userService,
            ITokenHelper tokenHelper,
            IRoleRepository roleRepository,
            IUserRoleRepository userRoleRepository,
            IRoleService roleService,
            IUserRoleService userRoleService,
            IPasswordHasher passwordHasher,
            IUserRepository userRepository)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _roleService = roleService;
            _userRoleService = userRoleService;
            _passwordHasher = passwordHasher;
            _userRepository = userRepository;
        }

        public IDataResult<User> Register(RegisterDto registerDto, string password)
        {
            _passwordHasher.CreatePasswordHash(password, out var passwordHash, out var passwordSalt);

            var user = new User
            {
                Email = registerDto.Email,
                UserName = registerDto.UserName.ToLower(),
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
            };

            _userRoleService.Add(new UserRole
            {
                User = user,
                RoleId = 1
            });

            return new SuccessDataResult<User>(user, "");
        }

        public IDataResult<User> Login(LoginDto loginDto)
        {
            var checkUser = _userService.GetByUsername(loginDto.Username);

            if (checkUser == null)
                return new ErrorDataResult<User>("Messages.UserNotFound");

            if (!_passwordHasher.VerifyPasswordHash(loginDto.Password, checkUser.PasswordHash, checkUser.PasswordSalt))
                return new ErrorDataResult<User>("Messages.PasswordError");

            var user = _userService.GetById(checkUser.Id);
            if (user.Status == false)
                return new ErrorDataResult<User>("Kullanıcınız pasife alınmıştır. Lütfen yönetici ile iletişime geçiniz.");
            return new SuccessDataResult<User>(user, "Messages.SuccessfulLogin");
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var userRoles = _roleService.GetListByUserId(user.Id);

            var accessToken = _tokenHelper.CreateToken(user, userRoles);

            return new SuccessDataResult<AccessToken>(accessToken, "Messages.AccessTokenCreated");
        }

        public IDataResult<User> ResetPassword(PasswordResetUserDto resetUserDto)
        {
            _passwordHasher.CreatePasswordHash(resetUserDto.Password, out var passwordHash, out var passwordSalt);
            var result = _userRepository.UpdatePassword(new User() { Id = resetUserDto.Id, PasswordHash = passwordHash, PasswordSalt = passwordSalt });
            if (result.Success)
                return new SuccessDataResult<User>(result.Data, result.Message);
            return new ErrorDataResult<User>(result.Data, result.Message);
        }
    }

}
