using API._Repositories;
using API._Services.Interfaces;
using API.Models;

namespace API._Services.Services
{
    public class SubscribeService : ISubscribeService
    {
        private readonly IRepositoryAccessor _repository;

        public SubscribeService(IRepositoryAccessor repository)
        {
            _repository = repository;
        }

        public async Task<bool> Subscribe(string email)
        {
            var data = new Subscribe {
                Email = email
            };
            _repository.Subscribe.Add(data);
            return await _repository.Save();
        }

        public async Task<bool> UnSubscribe(string email)
        {
            var data = await _repository.Subscribe.FindSingle(x => x.Email == email);
            _repository.Subscribe.Remove(data);
            return await _repository.Save();
        }
    }
}