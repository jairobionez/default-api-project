using DefaultProject.Domain.Entities;

namespace DefaultProject.Domain.Arguments
{
    public class ResponseBase
    {
        public ResponseBase()
        {
            Message = "Operação realizada com sucesso";
        }

        public string Message { get; set; }

        public static explicit operator ResponseBase(User user)
        {
            return new ResponseBase()
            {                
                Message = "Operação realizada com sucesso"
            };
        }
    }
}
;