using System.Collections.Generic;

namespace ProjectVenda.Login.Api.Interop.Dto
{
    public class LoginDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public IEnumerable<ClaimsDto> Claims { get; set; }
    }
}
