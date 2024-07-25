using BlogAppProject.Entity;

namespace BlogAppProject.Data.Abstract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags { get; }
        void CreateTag(Tag tag);
    }
}
