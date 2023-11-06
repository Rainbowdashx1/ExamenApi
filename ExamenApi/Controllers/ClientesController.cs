using ExamenApi.Models;
using ExamenApi.Models.Bl;
using ExamenApi.Models.Bl.Interface;
using ExamenApi.Models.ModelBD;
using ExamenApi.Models.Util;
using System;
using System.Net;
using System.Web.Http;
using static ExamenApi.Models.Dto.ClientesDto;

namespace ExamenApi.Controllers
{
    public class ClientesController : ApiController
    {
        private readonly IClienteBl ClienteBl;
        public ClientesController(IClienteBl ClienteBl) 
        {
            this.ClienteBl = ClienteBl;
        }
        [HttpPost]
        [Route("api/GetClient")]
        public IHttpActionResult GetClient(string email)
        {
            ResultSet result = new ResultSet();
            Clientes cli = new Clientes();
            try
            {
                cli = ClienteBl.ObtenerCliente(email, ref result);
                if (result.IsError)
                {
                    return StatusCode(HttpStatusCode.InternalServerError);
                }
                if (cli == null) 
                {
                    return StatusCode(HttpStatusCode.NotFound);
                }
            }catch(Exception) 
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return Ok(cli);
        }
        [HttpPost]
        [Route("api/CreateClient")]
        public IHttpActionResult CreateClient(CreateClientDto cliente)
        {
            ResultSet result = new ResultSet();
            try
            {
                ClienteBl.CrearCliente(cliente, ref result);
                if (result.IsError)
                {
                    return StatusCode(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return Ok();
        }
        [HttpPut]
        [Route("api/UpdateClient")]
        public IHttpActionResult UpdateClient(UpdateClientDto cliente)
        {
            ResultSet result = new ResultSet();
            try
            {
                ClienteBl.ActualizarCliente(cliente, ref result);
                if (result.IsError)
                {
                    return StatusCode(HttpStatusCode.InternalServerError);
                }
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            return Ok();
        }

    }
}
