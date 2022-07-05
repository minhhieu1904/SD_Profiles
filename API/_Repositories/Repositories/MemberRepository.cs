using API._Repositories.Interfaces;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        public MemberRepository(DBContext context) : base(context)
        {
        }
    }
}