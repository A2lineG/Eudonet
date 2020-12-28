using EudonetExercice.Entities;
using System.Collections.Generic;

namespace EudonetExercice.Services
{
    public interface IClientRepository
    {        
        IList<Client> GetClients();
        Client GetClientByEmail(string email);
        void AddClient(Client client);
    }
}
