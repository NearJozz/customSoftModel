using CustomSoftMaqueta.Domain.Entities;

namespace CustomSoftMaqueta.Domain.Interfaces
{
    public interface IUser
    {
        Task<List<UserModel>> GetAllUsers();
        Task<UserModel> GetUserById(Guid ide);
        Task<Boolean> CreateUser(UserModel user);

        Task<Boolean> UpdateUser(UserModel user);

        Task<Boolean> DeleteUser(Guid id);
    }
}
