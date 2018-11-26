using System.Threading.Tasks;

namespace Training.Authentication.MyAuth
{
    public interface IMyAuth
    {
        bool Authorize(string login, string pass);
        Task<bool> AuthorizeAsync(string login, string pass);
    }
}
