namespace KockstikSite.Database.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string LocalityPrefix { get; set; }
        public string LocalityName { get; set; }
        public string StreetPrefix { get; set; }
        public string StreetName { get; set;}
        public int HouseNumber { get; set; }
        public string HomeLetter { get; set; }
        public int BuildingNumber { get ; set; }
        public int ApartmentNumber { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; }

        public string getFullAddress()
        {
            return LocalityPrefix + LocalityName + " " + StreetPrefix + StreetName + " " + HomeLetter + HouseNumber + " " + ApartmentNumber;
        }
    }
}
