using API._Repositories.Interfaces;
using API.Data;
using API.Models;

namespace API._Repositories.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        public ContactRepository(DBContext context) : base(context)
        {
        }
    }
}