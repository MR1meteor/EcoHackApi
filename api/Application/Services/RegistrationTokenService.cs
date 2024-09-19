using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Application.Microservices.MailService.Interfaces;
using Application.Microservices.MailService.Models;
using Application.Services.Interfaces;
using Applizcation.Services;
using Domain.Entities;
using Infrastructure.Repository.Interfaces;

namespace Application.Services;

public class RegistrationTokenService(
    IRegistrationTokenRepository registrationTokenRepository,
    IMailService mailService,
    IUserService userService) : IRegistrationTokenService
{
    public async Task<RegistrationToken> GetByToken(Guid token)
    {
        var tokenData = await registrationTokenRepository.GetByToken(token);
        return tokenData ?? new RegistrationToken();
    }

    public async Task CreateByEmail(string email, IEnumerable<Claim> claims)
    {
        if (!new EmailAddressAttribute().IsValid(email) ||
            !await userService.IsRequestUserAdmin(claims))
        {
            return;
        }

        var tokenData = new RegistrationToken
        {
            Email = email,
            Token = Guid.NewGuid(),
            Expiration = DateTime.UtcNow.AddDays(1)
        };

        await registrationTokenRepository.Create(tokenData);

        var mailRequest = new MailRequest
        {
            Recepient = email,
            Subject = "Регистрация",
            Body = $"Токен: {tokenData.Token}, Дата истечения: {tokenData.Expiration}"
        };

        await mailService.SendMessage(mailRequest);
    }
}