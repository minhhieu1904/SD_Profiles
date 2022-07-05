using API._Repositories.Interfaces;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class SubscribeRepository : Repository<Subscribe>, ISubscribeRepository
    {
        public SubscribeRepository(DBContext context) : base(context)
        {
        }
    }
}