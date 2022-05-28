using Reviews.Models;

namespace Reviews.Services
{
    public class ReviewService : IReviewService
    {
        private static List<Review> reviews = new List<Review>();

        public List<Review> GetAll() { return reviews; }
        public Review Get(int id) { return reviews.Find(x => x.Id == id); }
        public void Create(string name, int rank, string description)
        {
            int nextId;
            if (reviews.Count != 0)
            {
                nextId = reviews.Max(x => x.Id) + 1;
            }
            else
                nextId = 1;

            reviews.Add(new Review() { Id = nextId, Name = name, Rank = rank,
                Description = description, CreatedDate = DateTime.UtcNow});
        }


        public void Edit(int id, string name, int rank, string description) {
            Review rev = Get(id);
            rev.Name = name;
            rev.Rank = rank;
            rev.Description = description;
            rev.CreatedDate = DateTime.UtcNow;

        }

        public void Delete(int id) { reviews.Remove(Get(id)); }

        public List<Review> FindByName(string name)
        {
            List<Review> found = new List<Review>();
            if (string.IsNullOrEmpty(name))
            {
                return GetAll();
            }
            
            for (int i = 0; i < reviews.Count; ++i)
            {
                if (reviews[i].Name.Equals(name))
                    found.Add(reviews[i]);

            }
            return found;
        }



    }
}
