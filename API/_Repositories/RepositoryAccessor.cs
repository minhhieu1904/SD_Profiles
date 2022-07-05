using API._Repositories.Interfaces;
using API._Repositories.Repositories;
using API.Data;

namespace API._Repositories
{
    public class RepositoryAccessor : IRepositoryAccessor
    {
        private DBContext _dbContext;

        public RepositoryAccessor(DBContext dbContext)
        {
            _dbContext = dbContext;
            About = new AboutRepository(_dbContext);
            Contact = new ContactRepository(_dbContext);
            Faq = new FaqRepository(_dbContext);
            Feature = new FeatureRepository(_dbContext);
            Member = new MemberRepository(_dbContext);
            Position = new PositionRepository(_dbContext);
            Subscribe = new SubscribeRepository(_dbContext);
            Menu = new MenuRepository(_dbContext);
        }

        public IAboutRepository About { get; private set; }

        public IContactRepository Contact { get; private set; }

        public IFaqRepository Faq { get; private set; }

        public IFeatureRepository Feature { get; private set; }

        public IMemberRepository Member { get; private set; }

        public IPositionRepository Position { get; private set; }

        public ISubscribeRepository Subscribe { get; private set; }

        public IMenuRepository Menu { get; private set; }

        public async Task<bool> Save()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}