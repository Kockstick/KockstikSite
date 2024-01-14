namespace KockstikSite.Database
{
    public class UnitOfWork
    {
        private AppDbContext context = new AppDbContext();
        private AddressesRepository addressesRepository;
        private LocationsRepository locationsRepository;

        public AddressesRepository Addresses
        {
            get
            {
                if (addressesRepository == null)
                    addressesRepository = new AddressesRepository(context);
                return addressesRepository;
            }
        }

        public LocationsRepository Locations
        {
            get
            {
                if (locationsRepository == null)
                    locationsRepository = new LocationsRepository(context);
                return locationsRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
