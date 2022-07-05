using API._Repositories.Interfaces;

namespace API._Repositories
{
    public interface IRepositoryAccessor
    {
        IAboutRepository About { get; }
        IContactRepository Contact { get; }
        IFaqRepository Faq { get; }
        IFeatureRepository Feature { get; }
        IMemberRepository Member { get; }
        IPositionRepository Position { get; }
        ISubscribeRepository Subscribe { get; }
        IMenuRepository Menu { get; }
        Task<bool> Save();
    }
}