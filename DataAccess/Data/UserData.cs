using DataAccess.DbAccess;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data;
// No** talk to the sql data access directly in our api project
// Yes** talk to Data folder
public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public Task<IEnumerable<UserModel>> GetUsers() =>
        _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { }); // dynamic is empty here.

    public async Task<UserModel?> GetUser(int id)
    {
        var results = await _db.LoadData<UserModel, dynamic>(
            "dbo.spUser_Get",
            new { Id = id });
        return results.FirstOrDefault(); // Defalut is NULL here
    }

    public Task InsertUser(UserModel user) =>
        _db.SaveData("dbo.spUser_Insert", new { user.FirstName, user.LastName }); // don't need to add id, auto_increament

    public Task UpdateUser(UserModel user) =>
        _db.SaveData("dbo.spUser_Update", user);

    public Task DeleteUser(int id) =>
        _db.SaveData("dbo.spUser_Delete", new { Id = id });
}
