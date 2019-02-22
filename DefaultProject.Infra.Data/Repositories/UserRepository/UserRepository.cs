using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Interfaces.Repositories.UserRepository;
using DefaultProject.Infra.Data.Context;
using System;

namespace DefaultProject.Infra.Data.Repositories.UserRepository
{
    public class UserRepository : BaseRepository<User, long>, IUserRepository
    {        
        public UserRepository(DefaultContext context) : base(context)
        {
        }
    }
}
