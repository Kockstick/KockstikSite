using KockstikSite.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace KockstikSite.Database;

public class LocationsRepository : IRepository<Location>
{
    private AppDbContext context;

    public LocationsRepository(AppDbContext context)
    {
        this.context = context;
    }

    public void Create(Location entity)
    {
        context.Locations.Add(entity);
    }

    public void Delete(int id)
    {
        var entity = context.Locations.Find(id);
        if (entity != null)
            context.Locations.Remove(entity);
    }

    public Location Get(int id)
    {
        return context.Locations.Find(id);
    }

    public IEnumerable<Location> GetAll()
    {
        return context.Locations;
    }

    public void Save()
    {
        context.SaveChanges();
    }

    public void Update(Location entity)
    {
        context.Entry(entity).State = EntityState.Modified;
    }
}
