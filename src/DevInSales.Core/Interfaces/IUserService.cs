using DevInSales.Core.Entities;

namespace DevInSales.EFCoreApi.Core.Interfaces
{
    public interface IUserService
    {
        public List<User> ObterUsers(string? name, string? DateMin, string? DateMax);

        public User? ObterPorId(int id);

        public int CriarUser(User user);

        public void RemoverUser(int id);

        public Task<bool> CadastrarUser(User user, string password, string? role);
        public Task<Object> Login(string email, string password);
    }
}