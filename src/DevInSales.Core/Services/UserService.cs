using DevInSales.Core.Data.Context;
using DevInSales.Core.Interfaces;
using DevInSales.EFCoreApi.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace DevInSales.Core.Entities
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Roles> _roleManager;
        private readonly IGenerateToken _generateToken;

        public UserService(DataContext context, UserManager<User> userManager, RoleManager<Roles> roleManager, IGenerateToken generateToken)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _generateToken = generateToken;
        }

        //Tratar erros
        public async Task<bool> CadastrarUser(User user, string password, string? role)
        {
            var usuario = await _userManager.CreateAsync(user, password);
            var verificarRole = await _roleManager.RoleExistsAsync(role.ToLower());
            if (verificarRole == true)
                await _userManager.AddToRoleAsync(user, role.ToLower());
            else
                await _userManager.AddToRoleAsync(user, "usuario");
            return usuario.Succeeded;
        }
        //DTO LOGINRequest que recebe username e password
        //DTO LoginResponse que retorna o token
        public async Task<Object> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email.ToLower());
            if (user != null && await _userManager.CheckPasswordAsync(user, password))
            {
                var userRole = await _userManager.GetRolesAsync(user);
                if (userRole.Count == 0)
                {
                    await _userManager.AddToRoleAsync(user, "administrador");
                }
                //retornar o token, o nome do usuario e a role como json ou como string via DTO
                var token = await _generateToken.GerarToken(user);
                var role = await _userManager.GetRolesAsync(user);
                return new
                {
                    token = token,
                    role = role
                };
            }
            //Buscar o usuario no userManager
            //atribuir o token
            // retornar o token como um json

            throw new NotImplementedException();
        }

        public int CriarUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }


        public User? ObterPorId(int id)
        {
            return _context.Users.Find(id);
        }


        public List<User> ObterUsers(string? name, string? DataMin, string? DataMax)
        {
            var query = _context.Users.AsQueryable();
            if (!string.IsNullOrEmpty(name))
                query = query.Where(p => p.Name.ToUpper().Contains(name.ToUpper()));
            if (!string.IsNullOrEmpty(DataMin))
                query = query.Where(p => p.BirthDate >= DateTime.Parse(DataMin));
            if (!string.IsNullOrEmpty(DataMax))
                query = query.Where(p => p.BirthDate <= DateTime.Parse(DataMax));

            return query.ToList();
        }
        public void RemoverUser(int id)
        {
            if (id >= 0)
            {
                var user = _context.Users.FirstOrDefault(user => user.Id == id);
                if (user != null)
                    _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}