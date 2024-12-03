using BookManagement.Core.Entities;
using BookManagement.Core.Interface.Repository;

namespace BookManagement.Infrastructure.Persistence.Repository
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users;

        // Inicializa a lista no construtor
        public UserRepository()
        {
            if (_users == null) // Inicializa apenas na primeira instância
            {
                _users = new List<User>
            {
                new User(1, "Gustavo Caçador", "gustavo.cacador@email.com", "123-456-7890"),
                new User(2, "Ana Silva", "ana.silva@email.com", "987-654-3210"),
                new User(3, "Carlos Oliveira", "carlos.oliveira@email.com", "555-123-4567")
            };
            }
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

        public async Task<User> CreateUser(User user)
        {
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1; // Gera um ID único
            _users.Add(user); // Adiciona à lista
            return await Task.FromResult(user); // Retorna o usuário criado
        }

        public async Task<User> UpdateUser(User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == user.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"Usuário com ID {user.Id} não encontrado.");
            }
            
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Phone = user.Phone;

            return await Task.FromResult(existingUser);
        }

        public async Task DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);

            if(user != null)
            {
                _users.Remove(user);
            }

            await Task.CompletedTask;
        }
    }
}