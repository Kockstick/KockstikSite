namespace KockstikSite.Database.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Prefix { get; set; }
        public string Name { get; set; }

        public List<Address> Addresses { get; set; }

        public Location() { }

        public Location (string prefix, string name)
        {
            Prefix = prefix;
            Name = name;
        }

        public Location(int id, string prefix, string name)
        {
            Id = id;
            Prefix = prefix;
            Name = name;
        }
    }
}
