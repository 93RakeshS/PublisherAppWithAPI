using Microsoft.VisualBasic;

namespace PublisherDomain
{
    public class Artist
    {
        public Artist() { 

            Covers = new List<Cover>();
        }
        public int ArtistId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IList<Cover> Covers { get; set; }
    }
}