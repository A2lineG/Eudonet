using EudonetExercice.Entities;
using EudonetExercice.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EudonetExercice.Services
{
    public class ClientRepository : IClientRepository
    {    
        private IList<Client> _clients;

        public ClientRepository()
        {
            _clients = new List<Client>
            {
                new Client { Name = "Dupont", FirstName = "Pierre", Email = "dupont.jean@exemple.ca", BirthDate = new DateTime(1983, 01, 03) },
                new Client { Name = "Tremblay", FirstName = "Jeanne", Email = "tremblay.jeanne@exemple.ca", BirthDate = new DateTime(1923, 04, 10) },
                new Client { Name = "Fontaine", FirstName = "Henri", Email = "fontaine.henri@exemple.ca", BirthDate = new DateTime(1945, 07, 23) },
                new Client { Name = "Depuis", FirstName = "Flora", Email = "dupuis.flora@exemple.ca", BirthDate = new DateTime(1965, 03, 15) },
                new Client { Name = "Sylvania", FirstName = "Jean", Email = "sylvania.jean@exemple.ca", BirthDate = new DateTime(1990, 08, 17) },
            };
        }

        public IList<Client> GetClients()
        {
            return _clients;
        }

        public Client GetClientByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentNullException(nameof(email));

            if (!_clients.Any(x => x.Email == email))
                throw new KeyNotFoundException(email);

            return _clients.FirstOrDefault(x => x.Email == email);
        }

        public void AddClient(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (!_clients.Any(x => x.Email == client.Email))
                _clients.Add(client);
            else throw new DuplicateClientException(client.Email);
        }
    }
}
