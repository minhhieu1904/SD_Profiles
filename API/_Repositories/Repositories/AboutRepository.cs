using API._Repositories.Interfaces;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class AboutRepository : Repository<About>, IAboutRepository
    {
        public AboutRepository(DBContext context) : base(context)
        {
        }
    }
}