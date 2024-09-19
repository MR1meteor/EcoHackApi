using Domain.Entities;
using Infrastructure.Dapper;
using Infrastructure.Dapper.Interfaces;
using Infrastructure.Repository.Interfaces;
using Infrastructure.Scripts.RegistrationToken;

namespace Infrastructure.Repository;

public class RegistrationTokenRepository(IDapperContext context) : IRegistrationTokenRepository
{
    public async Task Create(RegistrationToken tokenData)
    {
        var query = new QueryObject(PostgresRegistrationToken.Insert, tokenData);
        await context.Command<RegistrationToken>(query);
    }

    public async Task<RegistrationToken?> GetByToken(Guid token)
    {
        var query = new QueryObject(PostgresRegistrationToken.GetByToken, new { Token = token });
        return await context.FirstOrDefault<RegistrationToken>(query);
    }
}