using CustomSoftMaqueta.Domain.Interfaces;
using CustomSoftMaqueta.Infrastructure.data;
using MediatR;

namespace CustomSoftMaqueta.Application.User.commands
{
    public class DeleteUserHandler : IRequestHandler<DeleteUserCmd,bool>
    {
        private readonly IUser _UserRepository;
        private readonly IMediator _mediator;
        
        public DeleteUserHandler(IUser userRepository, IMediator mediator)
        {
            this._UserRepository = userRepository;
            this._mediator = mediator;
        }

        public async Task<bool> Handle(DeleteUserCmd request, CancellationToken cancellationToken)
        {
            
            var userExist = await this._UserRepository.GetUserById(request.Ide);
            if (userExist == null) { 
               return false;
            }
            var deleted = await this._UserRepository.DeleteUser(request.Ide);
            return deleted;
            
        }
    }
}
