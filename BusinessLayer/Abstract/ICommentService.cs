using EntityLayer;

namespace BusinessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        List<Comment> TGetDestinationById(int id);
        List<Comment> TGetListCommentWithDestination(); // Include
        List<Comment> TGetListCommentWithDestinationAndUser(int id);
    }
}
