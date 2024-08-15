using AutoMapper;
using CustomSoftMaqueta.Application.User.DTO;
using CustomSoftMaqueta.Domain.Interfaces;
using CustomSoftMaqueta.Infrastructure.data;
using MediatR;

namespace CustomSoftMaqueta.Application.User.Querys
{
    public class GetUserHandler : IRequestHandler<GetUserQuery, UserDTO>
    {
        private readonly IUser _UserRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GetUserHandler(IUser userRepository, IMediator mediator, IMapper _mapper)
        {
           this._UserRepository = userRepository;
           this._mediator = mediator;
           this._mapper = _mapper;

        }
        public async Task<UserDTO> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            var UserExist = await this._UserRepository.GetUserById(request.Ide);
            return _mapper.Map<UserDTO>(UserExist);
        }
    }
}
