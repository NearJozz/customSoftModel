using AutoMapper;
using CustomSoftMaqueta.Application.User.DTO;
using CustomSoftMaqueta.Domain.Interfaces;
using CustomSoftMaqueta.Infrastructure.data;
using MediatR;
using System.Collections.Generic;

namespace CustomSoftMaqueta.Application.User.Querys
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUserCmd, List<UserCleanDTO>>
    {
        private readonly IUser _UserRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GetAllUsersHandler(IUser userRepository, IMediator mediator, IMapper mapper)
        {
            this._UserRepository = userRepository;
            this._mediator = mediator;
            this._mapper = mapper;
        }
        public async Task<List<UserCleanDTO>> Handle(GetAllUserCmd request, CancellationToken cancellationToken)
        {
            var allUsers = await this._UserRepository.GetAllUsers();
            List< UserCleanDTO> List= this._mapper.Map<List<UserCleanDTO>>(allUsers);
            return List;

        }
    }
}
