using FluentValidation;
using MediatR;
using MStore.Application.Core;
using MStore.Application.Dtos.AppUsersDtos;
using MStore.Application.Interfaces;

namespace MStore.Application.AuthenticationBL
{
    public class UserLogin
    {
        public class Command : IRequest<Result<GetUserDto>>
        {
            public LoginDto Login { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Login).SetValidator(new LoginValidation());
            }
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
                var result = await _iUserRepo.Login(request.Login);
                return Result<GetUserDto>.Success(result);

            }
        }
    }
}
