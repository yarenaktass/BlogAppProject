using BlogAppProject.Data.Abstract;
using BlogAppProject.Data.EfCore;
using BlogAppProject.Entity;

namespace BlogAppProject.Data.Concrete
{
    public class EfTagRepository : ITagRepository
    {
        private BlogContext _context;

        public EfTagRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<Tag> Tags => _context.Tags;

        public void CreateTag(Tag tag)
        {
            _context.Tags.Add(tag);
            _context.SaveChanges();
        }
    }
}