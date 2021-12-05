using Microsoft.AspNetCore.Identity;
using ReadLater5.Models.Requests;
using ReadLater5.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IAuthService
    {
        Task<LoginResponse> LoginApi(LoginRequest model);
        Task<IdentityResult> RegisterApi(RegisterRequest model);
        Task<SignInResult> LoginApp(LoginRequest model);
        Task LogOut();
    }
}
