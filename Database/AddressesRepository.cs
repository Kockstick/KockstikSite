using KockstikSite.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace KockstikSite.Database
{
    public class AddressesRepository : IRepository<Address>
    {
        private AppDbContext context;

        public AddressesRepository(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Address entity)
        {
            context.Addresses.Add(entity);
        }

        public void Delete(int id)
        {
            var entity = context.Addresses.Find(id);
            if (entity != null)
                context.Addresses.Remove(entity);
        }

        public Address Get(int id)
        {
            return context.Addresses.Find(id);
        }

        public IEnumerable<Address> GetAll()
        {
            return context.Addresses;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Address entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
