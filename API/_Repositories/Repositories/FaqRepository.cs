using API._Repositories.Interfaces;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class FaqRepository : Repository<Faq>, IFaqRepository
    {
        public FaqRepository(DBContext context) : base(context)
        {
        }
    }
}