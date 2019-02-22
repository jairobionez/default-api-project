using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Interfaces.Repositories.Base;

namespace DefaultProject.Domain.Interfaces.Repositories.UserRepository
{
    public interface IUserRepository : IBaseRepository<User, long>
    {
    }
}
