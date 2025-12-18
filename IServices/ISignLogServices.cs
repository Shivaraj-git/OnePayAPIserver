using OnePayAPI.Models;

namespace OnePayAPI.IServices
{
    public interface ISignLogServices
    {

        Merchant SignUp(string fullName, string bussinessName, string email, string phoneNumber, string password);
        Merchant Login(string loginInput, string password);
    }
}
