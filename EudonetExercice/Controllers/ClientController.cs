using EudonetExercice.Entities;
using EudonetExercice.Exceptions;
using EudonetExercice.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace EudonetExercice.Controllers
{
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientRepository _clientRepo;

        public ClientController(IClientRepository clientRepository)
        {
            _clientRepo = clientRepository;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clientsFromRepo = _clientRepo.GetClients();
            return Ok(clientsFromRepo);
        }

        [HttpGet("{email}")]
        public IActionResult GetClientByEmail(string email)
        {
            try
            {
                var clientFromRepo = _clientRepo.GetClientByEmail(email);
                return Ok(clientFromRepo);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }   
        }

        [HttpPost]
        public IActionResult AddClient(Client client)
        {
            try
            {
                _clientRepo.AddClient(client);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (DuplicateClientException ex)
            {
                return Conflict(ex.Message);
            }           
        }
    }
}
