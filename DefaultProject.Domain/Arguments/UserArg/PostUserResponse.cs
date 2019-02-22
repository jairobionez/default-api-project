using DefaultProject.Domain.Entities;
using DefaultProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultProject.Domain.Arguments.UserArg
{
    public class PostUserResponse
    {
        public string FullName { get; set; }        

        public string Message { get; set; }

        public static explicit operator PostUserResponse(User user)
        {
            return new PostUserResponse()
            {
                FullName = user.FullName(),
                Message = "Usuário inserido com sucesso!"
            };
        }
    }
}
