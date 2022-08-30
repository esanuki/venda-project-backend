using System;

namespace ProjectVenda.Core.Interop.Login
{
    public class LoginResponseDto
    {
        public string AccessToken { get; set; }
        public Guid RefreshToken { get; set; }
        public double ExpiresIn { get; set; }
        public LoginDto Login { get; set; }
    }
}
