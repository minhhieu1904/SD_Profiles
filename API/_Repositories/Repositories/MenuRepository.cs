using API._Repositories.Interfaces;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class MenuRepository : Repository<Menu>, IMenuRepository
    {
        public MenuRepository(DBContext context) : base(context)
        {
        }
    }
}