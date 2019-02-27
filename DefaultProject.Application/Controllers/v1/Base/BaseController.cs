using DefaultProject.Domain.Entities;
using DefaultProject.Domain.Interfaces.Services;
using DefaultProject.Domain.Interfaces.Services.Base;
using DefaultProject.Infra.Data.Transactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DefaultProject.Application.Controllers.v1.Base
{
    public class BaseController :  ApiController
    {
        private readonly IUnitOfWork _uow;
        private IServiceBase _service;

        public BaseController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<HttpResponseMessage> ResponseAsync(object result, IServiceBase service)            
        {
            _service = service;

            if (_service.Valid)
            {
                try
                {
                    _uow.Commit();

                    return Request.CreateResponse(HttpStatusCode.OK, result);
                }catch(Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Aconteceu um error interno, por favor contate o administrador.");
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, new { errors = _service.Notifications });
            }
        }
    }
}
