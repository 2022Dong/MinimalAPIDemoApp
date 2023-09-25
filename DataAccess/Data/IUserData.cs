using DataAccess.Models;

namespace DataAccess.Data;
// api doesn't need to know about Dapper or sql
// just call actions throw below
public interface IUserData
{
    Task DeleteUser(int id);
    Task<UserModel?> GetUser(int id);
    Task<IEnumerable<UserModel>> GetUsers();
    Task InsertUser(UserModel user);
    Task UpdateUser(UserModel user);
}