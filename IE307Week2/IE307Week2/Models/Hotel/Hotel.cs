using System;

namespace IE307Week2.Models.Hotel
{
    public class HotelItem
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public int Price { get; set; }
    }
}
