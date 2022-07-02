using DevInSales.Api.Dtos;
using DevInSales.Core.Entities;
using DevInSales.EFCoreApi.Api.DTOs.Request;
using DevInSales.EFCoreApi.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RegexExamples;

namespace DevInSales.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Busca uma lista de usuários.
        /// </summary>
        /// <remarks>
        /// Pesquisa opcional: nome,data minima, data máxima
        /// <para>
        /// Exemplo de resposta:
        /// [
        ///   {
        ///     "id": 1,
        ///     "email": "joao@hotmail.com",
        ///     "name": "João",
        ///     "birthDate": "01/01/2000"
        ///   }
        /// ]
        /// </para>
        /// </remarks>
        /// <returns>Lista de endereços</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Pesquisa realizada com sucesso porém não retornou nenhum resultado</response>

        [HttpGet]
        [Authorize(Roles = "usuario, gerente, administrador")]
        public ActionResult<List<User>> ObterUsers(string? nome, string? DataMin, string? DataMax)
        {
            var users = _userService.ObterUsers(nome, DataMin, DataMax);
            if (users == null || users.Count == 0)
                return NoContent();

            var ListaDto = users.Select(user => UserResponse.ConverterParaEntidade(user)).ToList();

            return Ok(ListaDto);
        }

        /// <summary>
        /// Busca um usuário por id.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Exemplo de resposta:
        /// [
        ///   {
        ///     "id": 1,
        ///     "email": "joao@hotmail.com",
        ///     "name": "João",
        ///     "birthDate": "01/01/2000"
        ///   }
        /// ]
        /// </para>
        /// </remarks>
        /// <returns>Lista de endereços</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="404">Not Found, estado não encontrado no stateId informado.</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "usuario, gerente, administrador")]
        public ActionResult<User> ObterUserPorId(int id)
        {
            var user = _userService.ObterPorId(id);
            if (user == null)
                return NotFound();

            var UserDto = UserResponse.ConverterParaEntidade(user);

            return Ok(UserDto);
        }

        /// <summary>
        /// Cadastra um novo usuário.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Exemplo de resposta:
        /// [
        ///   {
        ///     "id": 1
        ///   }
        /// ]
        /// </para>
        /// </remarks>
        /// <returns>Lista de endereços</returns>
        /// <response code="200">Sucesso.</response>
        /// <response code="204">Pesquisa realizada com sucesso porém não retornou nenhum resultado</response>
        /// <response code="400">Formato invalido</response>
        [HttpPost]
        [Authorize(Roles = "gerente, administrador")]
        public ActionResult CriarUser(AddUser model)
        {
            var user = new User { UserName = model.Name, BirthDate = model.BirthDate, };

            var verifyEmail = new EmailValidate();

            if (!verifyEmail.IsValidEmail(user.Email))
                return BadRequest("Email inválido");

            if (user.BirthDate.AddYears(18) > DateTime.Now)
                return BadRequest("Usuário não tem idade suficiente");

            if (
                user.PasswordHash.Length < 4
                || user.PasswordHash.Length == 0
                || user.PasswordHash.All(ch => ch == user.PasswordHash[0])
            )
                return BadRequest(
                    "Senha inválida, deve conter pelo menos 4 caracteres e deve conter ao menos um caracter diferente"
                );

            var id = _userService.CriarUser(user);

            return CreatedAtAction(nameof(ObterUserPorId), new { id = id }, id);
        }

        /// <summary>
        /// Deleta um usuário.
        /// </summary>
        /// <response code="204">Endereço deletado com sucesso</response>
        /// <response code="404">Not Found, endereço não encontrado.</response>
        /// <response code="500">Internal Server Error, erro interno do servidor.</response>

        [HttpDelete("{id}")]
        [Authorize(Roles = "administrador")]
        public ActionResult ExcluirUser(int id)
        {
            try
            {
                _userService.RemoverUser(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("usuario não existe"))
                    return NotFound();

                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { Mensagem = ex.Message }
                );
            }
        }

        [HttpPost("SignUp")]
        [AllowAnonymous]
        public async Task<ActionResult> CadastraUsuario([FromBody] AddRegistration model)
        {
            var user = new User
            {
                Name = model.Name,
                Email = model.Email,
                UserName = model.Name,
                BirthDate = model.BirthDate,
            };
            var id = await _userService.CadastrarUser(user, model.Password, model.Role);
            if (id == true)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("Login")]
        public async Task<Object> Login([FromBody] LoginRequest model)
        {
            var logar = _userService.Login(model.Email, model.Password);
            return new { token = logar };
        }
    }
}
