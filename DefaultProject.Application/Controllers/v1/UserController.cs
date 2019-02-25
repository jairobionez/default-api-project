using DefaultProject.Application.Controllers.v1.Base;
using DefaultProject.Domain.Arguments;
using DefaultProject.Domain.Arguments.UserArg;
using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Services.UserService;
using DefaultProject.Infra.Data.Transactions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace DefaultProject.Application.Controllers.v1
{
    [RoutePrefix("api/user")]
    public class UserController : BaseController
    {
        private readonly IUserService _userService;

        public UserController(IUnitOfWork uow, IUserService userService) : base(uow)
        {
            _userService = userService;
        }

        /// <summary>
        /// Busca todos os usuários
        /// </summary>
        /// <returns>Retorna um lista contendo todos os usuários</returns>
        [HttpGet]
        [Route("")]
        [ResponseType(typeof(List<User>))]
        public async Task<HttpResponseMessage> GetUser()
        {
            var result = _userService.Get();

            return await ResponseAsync(result, _userService);
        }

        /// <summary>
        /// Retorna um usuário por sua chave de indentificação
        /// </summary>
        /// <param name="key"></param>
        /// <returns>Retorna o usuário especifico</returns>
        [HttpGet]
        [Route("{key}")]
        [ResponseType(typeof(User))]
        public async Task<HttpResponseMessage> GetUserById(long key)
        {
            var result = _userService.GetById(key);

            return await ResponseAsync(result, _userService);
        }

        /// <summary>
        /// Inseri um usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna o nome completo do usuário e status da operação</returns>
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(PostUserResponse))]
        public async Task<HttpResponseMessage> InsertUser(User user)
        {
            var result = _userService.Post(user);

            return await ResponseAsync(result, _userService);
        }

        /// <summary>
        /// Atualiza um usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Retorna o usuário atualizado</returns>
        [HttpPut]
        [Route("")]
        [ResponseType(typeof(UpdateUserResponse))]
        public async Task<HttpResponseMessage> UpdateUser(User user)
        {            
            var result = _userService.Put(user);

            return await ResponseAsync(result, _userService);
        }

        /// <summary>
        /// Delete um usuário por sua chave de identificação
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna o status da operação</returns>
        [HttpDelete]
        [Route("{key}")]
        [ResponseType(typeof(ResponseBase))]
        public async Task<HttpResponseMessage> DeleteUser(long id)
        {
            var result = _userService.Delete(id);

            return await ResponseAsync(result,  _userService);
        }
    }
}
