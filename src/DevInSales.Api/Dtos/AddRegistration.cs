
namespace DevInSales.Api.Dtos
{
    public record AddRegistration(string Email, string Password, string Name, DateTime BirthDate, string Role) { };
}