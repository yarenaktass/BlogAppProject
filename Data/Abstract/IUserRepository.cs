using BlogAppProject.Entity;

namespace BlogAppProject.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void CreateUser(User user);
    }
}
