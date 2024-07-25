using BlogAppProject.Entity;

namespace BlogAppProject.Data.Abstract
{
    public interface ICommentRepository
    {

        IQueryable<Comment> Comments { get; }
        void CreateComment(Comment comment);
    }
}
