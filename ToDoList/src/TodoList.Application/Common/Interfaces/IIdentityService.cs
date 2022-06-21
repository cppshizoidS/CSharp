using TodoList.Application.Common.Models;

namespace TodoList.Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> CreateUserAsync(string userName, string password);
    Task<bool> ValidateUserAsync(UserForAuthentication userForAuthentication);
    Task<ApplicationToken> CreateTokenAsync(bool populateExpiry);
    Task<ApplicationToken> RefreshTokenAsync(ApplicationToken token);
}