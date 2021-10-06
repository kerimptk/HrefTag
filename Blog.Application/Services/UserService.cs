using BaseCore.Utilities.Results;
using Blog.Domain.Entities;
using Blog.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public User FindByEmailAsyncUser(string email)
        {
            return _userRepository.Get(i => i.Email == email);
        }

        public User GetById(int id)
        {
            return _userRepository.Get(i => i.Id == id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.Get(i => i.UserName == username);
        }

        public bool IsUserExistByUsername(string username, string currentUsername = null)
        {
            var result = true;

            if (username != currentUsername)
                result = _userRepository.Get(i => i.UserName == username) == null;

            return result;
        }

        public IResult IsUserExistByEmail(string email, string currentEmail = null)
        {
            if (email == currentEmail)
                return new ErrorResult();

            var user = _userRepository.Get(i => i.Email == email);
            if (user != null)
                return new SuccessResult();

            return new ErrorResult();
        }

        public IDataResult<User> Add(User user)
        {
            var result = _userRepository.Add(user);

            return new SuccessDataResult<User>(user,result.Message);
        }

        public IDataResult<User> Update(User user)
        {
            var result = _userRepository.Update(user);
            return new SuccessDataResult<User>(result.Message);

        }

        public async Task<IDataResult<User>> AddAsync(User user)
        {
            var result = await _userRepository.AddAsync(user);
            return new SuccessDataResult<User>(result.Message);
        }

        public async Task<IDataResult<User>> UpdateAsync(User user)
        {
            var result = await _userRepository.UpdateAsync(user);
            return new SuccessDataResult<User>(result.Message);
        }

        public User GetByEmail(string email)
        {
            return _userRepository.Get(i => i.Email == email);
        }

        public List<User> GetList()
        {
            return _userRepository.GetList().ToList();
        }

        public List<User> GetListAktif()
        {
            return _userRepository.GetList().Where(i=> i.Status == true).ToList();
        }
    }
}
