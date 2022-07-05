using API._Repositories.Interfaces;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class FeatureRepository : Repository<Feature>, IFeatureRepository
    {
        public FeatureRepository(DBContext context) : base(context)
        {
        }
    }
}