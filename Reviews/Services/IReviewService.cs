using Reviews.Models;

namespace Reviews.Services
{
    public interface IReviewService
    {

        public List<Review> GetAll();
        public Review Get(int id);
        public void Create(string name, int rank, string description);


        public void Edit(int id, string name, int rank, string description);

        public void Delete(int id);

        public List<Review> FindByName(string name);


    }
}
