using Domain.Entities;

namespace Infrastructure.Repository.Interfaces;

public interface IRegistrationTokenRepository
{
    Task Create(RegistrationToken tokenData);
    Task<RegistrationToken?> GetByToken(Guid token);
}