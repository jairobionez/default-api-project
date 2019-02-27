using System.Collections.Generic;
using System.Linq;
using DefaultProject.Domain.Arguments;
using DefaultProject.Domain.Arguments.UserArg;
using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Interfaces.Repositories.UserRepository;
using Flunt.Notifications;

namespace DefaultProject.Domain.Services.UserService
{
    public class UserService : Notifiable, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IList<User> Get()
        {
            return _userRepository.Get();
        }

        public User GetById(long id)
        {
            if (id == 0)
                AddNotification("Id", "O identificador de busca está nulo");

            if(Invalid)
                return null;

            return _userRepository.GetById(id);
        }

        public PostUserResponse Post(User obj)
        {
            if (obj.Name == null)
                AddNotification("Name", "Nome e sobrenome obrigatórios");

            if(Invalid)
                return null;

            return (PostUserResponse)_userRepository.Insert(obj);
        }

        public UpdateUserResponse Put(User obj)
        {
            User user = _userRepository.GetById(obj.Id);

            if (user == null)
                AddNotification("Usuário", "O usuário não foi encontrado");
            else
            {
                user.Name = obj.Name;
                user.Address = obj.Address;
            }

            if (Invalid)
                return null;

            return (UpdateUserResponse)_userRepository.Update(user);
        }

        public ResponseBase Delete(long id)
        {
            User user = _userRepository.GetById(id);

            if(user == null)
                AddNotification("Usuário", "O usuário não foi encontrado");

            if(Valid)
                _userRepository.Delete(user);

            return new ResponseBase();
        }
    }
}
