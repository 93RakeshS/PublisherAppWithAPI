using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData
{
    public class PubContext:DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Author> Author { get; set; }   
        public DbSet<Book> Books { get; set; }
        public DbSet<Cover> Covers { get; set; }

        public PubContext(DbContextOptions<PubContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {  
            var ArtistList = new Artist[]
            {
                new Artist() {ArtistId = 1, FirstName="Pablo", LastName="Picaso"},
                new Artist() {ArtistId = 2, FirstName="Dee", LastName="Bell"},
                new Artist() {ArtistId = 3, FirstName="Kath", LastName="Kuharic"},
            };
            modelBuilder.Entity<Artist>().HasData(ArtistList);

            var CoversList = new Cover[] { 
                new Cover() { CoverId = 1, BookId = 1 ,DesignIdeas ="Left Hand In The Dark", DigitalOnly = true},
                new Cover() { CoverId = 2, BookId = 2, DesignIdeas ="Big Ear In Clouds", DigitalOnly = false},
                new Cover() { CoverId = 3, BookId = 3, DesignIdeas ="Clock On The Wall", DigitalOnly = false}
            };
            modelBuilder.Entity<Cover>().HasData(CoversList);
        }
    }
}