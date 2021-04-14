using Blog.Domain.Entities;
using System.Collections.Generic;

namespace Blog.Domain.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<Role> roles);
    }
}