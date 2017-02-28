namespace Logs.Authentication.Contracts
{
    public interface IAuthenticationProvider
    {
        bool IsAuthenticated { get; }
    }
}