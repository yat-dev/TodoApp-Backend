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
            var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier).ToString();
                
            return int.TryParse(userIdClaim, out var userId) ? userId : 0;
        }
    }

    public string UserName
    {
        get
        {
            return _httpContextAccessor.HttpContext?.User?
                .FindFirst(ClaimTypes.Name).ToString() ?? string.Empty;
        }
    }
}