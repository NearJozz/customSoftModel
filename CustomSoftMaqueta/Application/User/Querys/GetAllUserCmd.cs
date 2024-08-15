using CustomSoftMaqueta.Application.User.DTO;
using MediatR;

namespace CustomSoftMaqueta.Application.User.Querys
{
    public class GetAllUserCmd : IRequest<List<UserCleanDTO>>
    {

    }
}
