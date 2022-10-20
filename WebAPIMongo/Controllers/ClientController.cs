using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIMongo.Models;
using WebAPIMongo.Services;

namespace WebAPIMongo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientService _clientService; //sempre privado

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]   //Get sem parametros traz todos
        public ActionResult<List<Client>> Get() => _clientService.Get();

        [HttpGet("{name}", Name ="GetName")]
        public ActionResult<Client> GetByName(string name)
        {
            var client = _clientService.GetByName(name);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);  
        }

        [HttpGet("address/{id:length(24)}", Name = "GetClientAddress")]
        public ActionResult<Client> GetByAddress(string id)
        {
            var client = _clientService.GetByAddress(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }


        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }
        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {
            _clientService.Create(client);
            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }

        [HttpPut]
        public ActionResult<Client> Put(Client clientIn, string id)
        {
            var client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound("Não encontrado");
            }
            _clientService.Update(client.Id, clientIn);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Client> Delete(string id)
        {
            Client client = _clientService.Get(id);
            if (client == null)
            {
                return NotFound();
            }
            _clientService.Remove(client);

            return NoContent();
        }

    }
}
