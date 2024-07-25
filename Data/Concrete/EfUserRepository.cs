using BlogAppProject.Data.Abstract;
using BlogAppProject.Data.EfCore;
using BlogAppProject.Entity;

namespace BlogAppProject.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private BlogContext _context;

        public EfUserRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}