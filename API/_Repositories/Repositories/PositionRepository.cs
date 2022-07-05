using API._Repositories.Interfaces;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class PositionRepository : Repository<Position>, IPositionRepository
    {
        public PositionRepository(DBContext context) : base(context)
        {
        }
    }
}