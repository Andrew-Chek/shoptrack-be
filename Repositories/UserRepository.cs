using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using shoptrack_be.Models;

namespace shoptrack_be.Repositories;

public class UserRepository : Repository<User>, IUserService
{
    private readonly ShopTrackDbContext _context;
    private readonly AppSettings _appSettings;
    private readonly EmailService _emailService;
    public UserRepository(
        ShopTrackDbContext context, 
        IOptions<AppSettings> appSettings
    ) : base(context)
    {
        _context = context;
        _appSettings = appSettings.Value;

        HttpClient httpClient = new HttpClient();
        _emailService = new EmailService(httpClient);
    }

    public async Task<AuthenticateResponse?> Authenticate(AuthenticateRequest model)
    {
        var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == model.Username);

        if (!PasswordHasher.VerifyPassword(model.Password, user.Password)) return null;

        // authentication successful so generate jwt token
        var token = await generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public async Task<string> SendForgotPasswordEmail(string userEmail)
    {
        // Generate a reset code
        string resetCode = _emailService.GenerateResetCode(6);

        // Send the forgot password email
        bool emailSent = await _emailService.SendEmailAsync("andrii.chekyrda@gmail.com", userEmail, "forgot password",  resetCode);

        if (emailSent)
        {
            return "Forgot password email sent successfully.";
        }
        else
        {
            return "Failed to send forgot password email.";
        }
    }

    public Task<IEnumerable<User>> GetAll()
    {
        return base.GetAllAsync();
    }

    public Task<User?> GetById(int id)
    {
        return base.GetByIdAsync(id);
    }

    private async Task<string> generateJwtToken(User user)
        {
            //Generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = await Task.Run(() =>
            {

                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                return tokenHandler.CreateToken(tokenDescriptor);
            });

            return tokenHandler.WriteToken(token);
        }

    public override Task UpdateAsync(int id, User user)
    {
        user.Password = PasswordHasher.HashPassword(user.Password);
        return base.UpdateAsync(id, user);
    }

    public override Task AddAsync(User user)
    {
        user.Password = PasswordHasher.HashPassword(user.Password);
        return base.AddAsync(user);
    }
}
