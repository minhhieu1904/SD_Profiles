namespace API._Services.Interfaces
{
    public interface ISubscribeService
    {
        Task<bool> Subscribe(string email);
        Task<bool> UnSubscribe(string email);
    }
}