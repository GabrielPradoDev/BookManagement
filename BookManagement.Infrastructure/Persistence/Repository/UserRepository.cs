using BookManagement.Core.Entities;
using BookManagement.Core.Interface.Repository;

namespace BookManagement.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        // Inicializa a lista no construtor
        public UserRepository()
        {
            _users = new List<User>
            {
                new User(1, "Gustavo Caçador", "gustavo.cacador@email.com", "123-456-7890"),
                new User(2, "Ana Silva", "ana.silva@email.com", "987-654-3210"),
                new User(3, "Carlos Oliveira", "carlos.oliveira@email.com", "555-123-4567")
            };
        }

        public Task<List<User>> GetAllUsers()
        {
            return Task.FromResult(_users);
        }

        public Task<User> GetById(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }
    }
}