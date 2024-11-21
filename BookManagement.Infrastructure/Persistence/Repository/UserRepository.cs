using BookManagement.Core.Entities;
using BookManagement.Core.Interface.Repository;

namespace BookManagement.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<List<User>> GetAllUsers()
        {
            var users = new List<User>
        {
            new User("Gustavo Caçador", "gustavo.cacador@email.com", "123-456-7890"),
            new User("Ana Silva", "ana.silva@email.com","987-654-3210"),
            new User("Carlos Oliveira", "carlos.oliveira@email.com", "555-123-4567")
        };

            return Task.FromResult(users);
        }
    }
}
