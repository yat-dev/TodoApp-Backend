using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using TodoApp.Application.Common.Interfaces;

namespace TodoApp.Infrastructure.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public int UserId
    {
        get
        {
            var claim = _httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.NameIdentifier);
                
            if (claim == null)
                return 0;
                
            return int.TryParse(claim.Value, out var userId) ? userId : 0;
        }
    }

    public string Username
    {
        get
        {
            var claim = _httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.Name);
                
            return claim?.Value ?? string.Empty;
        }
    }
}