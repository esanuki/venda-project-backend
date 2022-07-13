using System;

namespace ProjectVenda.Login.Api.Interop.Dto
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public LoginDto Login { get; set; }
    }
}
