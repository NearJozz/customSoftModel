using CustomSoftMaqueta.Domain.Entities;
using CustomSoftMaqueta.Domain.Interfaces;
using CustomSoftMaqueta.Infrastructure.data;
using MediatR;

namespace CustomSoftMaqueta.Application.User.commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCmd,bool>
    {
        private readonly IUser _UserRepository;
        private readonly IMediator _mediator;
        public CreateUserHandler(IUser userRepository, IMediator mediator)
        {
            _UserRepository = userRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreateUserCmd request, CancellationToken cancellationToken)
        {
            UserModel newUser = new(new Guid(), request.Name, request.Email, request.Password);
            var isCreated=await this._UserRepository.CreateUser(newUser);
            return isCreated;
        }
    }
}
