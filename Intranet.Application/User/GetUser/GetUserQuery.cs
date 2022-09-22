using Intranet.Application.User.Registration;
using MediatR;

namespace Intranet.Application.User.GetUser
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
    }
    public class GetUserResponse
    {
        public string Email { get; set; }
        public string UserId { get; set; }
        public string PhoneNumber { get; set; }
    }

}
