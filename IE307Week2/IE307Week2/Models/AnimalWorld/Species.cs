using System;

namespace IE307Week2.Models.AnimalWorld
{
    public class AnimalSpeciesItem
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string ConservationStatus { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
    }
}
