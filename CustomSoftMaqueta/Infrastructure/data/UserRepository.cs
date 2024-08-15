
using CustomSoftMaqueta.Domain.Entities;
using CustomSoftMaqueta.Domain.Interfaces;
using Dapper;
using System.Data;

namespace CustomSoftMaqueta.Infrastructure.data
{
    public class UserRepository : IUser
    {
        private readonly IDbConnection _dbConnection;
        public UserRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection ?? throw new ArgumentNullException(nameof(dbConnection));
        }
        public async Task<List<UserModel>> GetAllUsers()
        {
           
            
            var users = await _dbConnection.QueryAsync<UserModel>("SELECT * FROM get_all_users()");
            List<UserModel> result = users.ToList();
            return result;
        }
        public async Task<UserModel> GetUserById(Guid Ide)
        {
            var parameters = new DynamicParameters();
            parameters.Add("p_Ide", Ide);
            var user= await this._dbConnection.QueryFirstOrDefaultAsync<UserModel>("select * from  get_user_by_ide(@p_Ide)", parameters, commandType: CommandType.Text);
            return user;

        }
        public async Task<Boolean> CreateUser(UserModel User)
        {

            var parameters = new DynamicParameters();
            parameters.Add("p_name", User.Name);
            parameters.Add("p_email", User.Email);
            parameters.Add("p_password", User.Password);
            await this._dbConnection.QueryAsync<UserModel>("select * from insert_user(@p_name,@p_email,@p_password)",parameters,commandType:CommandType.Text);

            return true;
        }
        public async Task<Boolean> UpdateUser(UserModel User)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_Ide", User.Ide);
                parameters.Add("p_Name", User.Name);
                parameters.Add("p_Email", User.Email);
                parameters.Add("p_Password", User.Password);
                await this._dbConnection.QueryAsync<UserModel>("select *  from update_user(@p_ide,@p_name,@p_email,@p_password)", parameters, commandType: CommandType.Text);
                return true;
            }
            catch (Exception ex) {
                throw new Exception("Error en la ejecucion del sp");
            }
        }
        public async Task<Boolean> DeleteUser(Guid Ide) {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("p_Ide", Ide);
                var user = await this._dbConnection.QueryFirstOrDefaultAsync<UserModel>("call delete_user(@p_Ide)", parameters, commandType: CommandType.Text);
                return true;
            }
            catch (Exception ex) { 
                throw new Exception("Error en SP "+ex.ToString);
            }

        }
    }
}
