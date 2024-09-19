using System.Security.Claims;
using Domain.Entities;

namespace Application.Services.Interfaces;

public interface IRegistrationTokenService
{
    Task<RegistrationToken> GetByToken(Guid token);
    Task CreateByEmail(string email, IEnumerable<Claim> claims);
}