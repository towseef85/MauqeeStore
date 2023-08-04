using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.AppUsersDtos;
using MStore.Application.Interfaces;

namespace MStore.Application.AuthenticationBL
{
    public class LoggedInUser
    {
        public class Command : IRequest<Result<GetUserDto>>
        {
            public string Email { get; set; }
        }

        public class Handler : IRequestHandler<Command, Result<GetUserDto>>
        {


            private readonly IUserRepository _iUserRepo;
            public Handler(IUserRepository iUserRepo)
            {
                _iUserRepo = iUserRepo;
            }
            public async Task<Result<GetUserDto>> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = await _iUserRepo.GetCurrentUser(request.Email);
               
                return Result<GetUserDto>.Success(user);
            }


        }
    }
}
