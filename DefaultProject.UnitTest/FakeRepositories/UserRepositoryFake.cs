using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Interfaces.Repositories.UserRepository;
using System.Collections.Generic;
using System.Linq;

namespace DefaultProject.UnitTest.FakeRepositories
{
    public class UserRepositoryFake : IUserRepository
    {
        public List<User> list = new List<User>();

        public void Delete(User obj)
        {
            list.Remove(obj);
        }

        public IList<User> Get()
        {
            return list.ToList();
        }

        public User GetById(long id)
        {
            return list.Where(o => o.Id == id).FirstOrDefault();
        }

        public User Insert(User obj)
        {
            list.Add(obj);

            return obj;
        }

        public User Update(User obj)
        {
            list.Where(o => o.Equals(obj))
                .ToList()
                .ForEach(o => o = obj);

            return obj;
        }
    }
}
