using AutoMapper;
using CustomSoftMaqueta.Application.User.DTO;
using CustomSoftMaqueta.Domain.Entities;
using CustomSoftMaqueta.Domain.Interfaces;
using CustomSoftMaqueta.Infrastructure.data;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CustomSoftMaqueta.Application.User.commands
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserCmd, UserCleanDTO>
    {
        private readonly IUser _UserRepository;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UpdateUserHandler(IUser userRepository, IMediator mediator, IMapper mapper)
        {
            this._UserRepository = userRepository;
            this._mediator = mediator;
            this._mapper = mapper;
        }
        public async Task<UserCleanDTO?> Handle(UpdateUserCmd request, CancellationToken cancellationToken)
        {
           
                var UserExist = await this._UserRepository.GetUserById(request.Ide);
                if (UserExist == null)
                {
                    return null;
                }
                if (!string.IsNullOrEmpty(request.Name))
                {
                    UserExist.UpdateName(request.Name);
                }
                if (!string.IsNullOrEmpty(request.Email))
                {
                    UserExist.UpdateEmail(request.Email);
                }
                if (!string.IsNullOrEmpty(request.Password))
                {
                    UserExist.UpdatePassword(request.Password);
                }

                Boolean isUpdated = await this._UserRepository.UpdateUser(UserExist);

                return _mapper.Map<UserCleanDTO>(UserExist);
        }
            
    }
}
