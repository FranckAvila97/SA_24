using SA_W4.Helpers;
using SA_W4.Models;
using SA_W4.Pages;

namespace SA_W4
{
    public interface IUser
    {
        Response GetUsers();
        Response CreateUser(UserModel model);
        Response Login(UserModel model);
        Response UpdateUser(UserModel model);
        Response DeleteUser(int idUser);
    }
}