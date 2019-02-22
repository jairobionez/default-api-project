using DefaultProject.Domain.Arguments;
using DefaultProject.Domain.Arguments.UserArg;
using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Interfaces.Notifications;
using DefaultProject.Domain.Interfaces.Services;
using DefaultProject.Domain.Interfaces.Services.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefaultProject.Domain.Services.UserService
{
    public interface IUserService : IServiceBase
    {
        IList<User> Get();

        User GetById(long id);

        PostUserResponse Post(User obj);

        UpdateUserResponse Put(User obj);

        ResponseBase Delete(long id);
    }
}
