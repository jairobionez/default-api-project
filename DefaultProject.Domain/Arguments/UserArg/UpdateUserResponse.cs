using DefaultProject.Domain.Entities;
using DefaultProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefaultProject.Domain.Arguments.UserArg
{
    public class UpdateUserResponse
    {
        public Name Name { get; set; }

        public Address Address { get; set; }

        public string Message { get; set; }

        public static explicit operator UpdateUserResponse(User user)
        {
            return new UpdateUserResponse()
            {
                Name = user.Name,
                Address = user.Address,
                Message = "Usuário alterado com sucesso!"
            };
        }
    }
}
