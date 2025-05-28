using lab6.Models;

namespace lab6.Core.Services
{
    public interface IUserService
    {
        User? Authenticate(string login, string password);

        User Register(string login, string password);
    }
}
