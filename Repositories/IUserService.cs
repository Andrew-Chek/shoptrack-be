using shoptrack_be.Models;

public interface IUserService
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int id);
    Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model);
}
